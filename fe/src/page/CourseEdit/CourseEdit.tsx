import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import { Container, AppBar, Tabs, Tab, Paper } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import a11yProps from '../../component/A11yProps/A11yProps';
import TabPanel from '../../component/TabPanel/TabPanel';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import CustomTable from '../../component/CustomTable/CustomTable';
import PageName from '../../component/PageName/PageName';
import CodeBook from '../../component/CodeBook/CodeBook';
import GetUserToken from '../../core/GetUserToken';
import GetUrlParam from '../../core/GetUrlParam';
import PropTypes from 'prop-types';
import { Price } from '../../WebModel/Shared/Price';
import { AddCourse } from '../../WebModel/Course/AddCourse';
import { UpdateCourse } from '../../WebModel/Course/UpdateCourse';
import CustomCheckBox from '../../component/CustomCheckBox/CustomCheckBox';


export default function CourseEdit() {
    const { t } = useTranslation();
    var id = GetUrlParam("id");
    const classes = useStyles();
    const [valueTab, setValueTab] = React.useState(0);
    const [courseName, setCourseName] = React.useState("");
    const [courseDescription, setCourseDescription] = React.useState("");
    const [isPrivateCourse, setIsPrivateCourse] = React.useState(false);
    const [coursePrice, setCoursePrice] = useState(0);
    const [courseSale, setCourseSale] = useState(0);
    const [defaultMinimumStudents, setDefaultMinimumStudents] = useState(0);
    const [defaultMaximumStudents, setDefaultMaximumStudents] = useState(0);
    const [courseType, setCourseType] = useState("");
    const [courseStatus, setCourseStatus] = useState("");
    const [courseTerm, setCourseTerm] = useState([]);

    const handleChangeCourseName = (event: any) => {
        setCourseName(event.target.value);
    }

    const handleChangeCourseDescription = (event: any) => {
        setCourseDescription(event.target.value);
    }
    const handleChangeIsPrivateCourse = (event: any) => {
        setIsPrivateCourse(event.target.checked)
    }

    const handleChangeCoursePrice = (event: any) => {
        setCoursePrice(event.target.value);
    }

    const handleChangeCourseSale = (e: any) => {
        setCourseSale(e.target.value);
    }

    const handleChangeDefaultMinimumStudents = (e: any) => {
        setDefaultMinimumStudents(e.target.value);
    }
    const handleChangeDefaultMaximumStudents = (e: any) => {
        setDefaultMaximumStudents(e.target.value);
    }
    const handleChangeCourseType = (e: any) => {
        setCourseType(e.target.value);
    }
    const handleChangeCourseStatus = (e: any) => {
        setCourseStatus(e.target.value);
    }

    const handleChangeTab = (event: any, newValue: any) => {
        setValueTab(newValue);
    }
    ValidatorForm.addValidationRule('isValidPrice', (value: number) => {
        return value >= 0
    });
    ValidatorForm.addValidationRule('isValidSale', (value: number) => {
        return value >= 0 && value <= 100
    });

    ValidatorForm.addValidationRule('isValidStudenCount', (value: number) => {
        if (defaultMaximumStudents < 0 || defaultMinimumStudents < 0) {
            return false;
        }
        if (defaultMaximumStudents >= 0 && defaultMinimumStudents >= 0) {
            if (defaultMaximumStudents >= defaultMinimumStudents) {
                return true;
            }
        }
        return false;
    });

    useEffect(() => {
        const fetchData = async () => {
            if (id === "") {
                setValueTab(0);
            }
            else {
                await axiosInstance.get("webportal/Course/GetCourseDetail", {
                    params: {
                        accessToken: GetUserToken(),
                        courseId: id
                    }
                }).then(function (response: any) {
                    setIsPrivateCourse(response.data.data.isPrivateCourse);
                    setCourseSale(response.data.data.coursePrice.sale);
                    setCoursePrice(response.data.data.coursePrice.price);
                    setCourseName(response.data.data.name);
                    setCourseDescription(response.data.data.description);
                    setCourseStatus(response.data.data.courseStatusId);
                    setCourseType(response.data.data.courseTypeId);
                    setValueTab(0);
                });
                axiosInstance.get("webportal/CourseTerm/GetAllTermInCourse",{params:{
                    accessToken: GetUserToken(),
                    courseId:GetUrlParam("id")
                }}).then(function(response){
                    setCourseTerm(response.data.data);
                });

            }
        }
        fetchData();
    }, []);

    const saveBasicData = () => {
        if (id === "") {
            const price = new Price(coursePrice, courseSale);
            const obj = new AddCourse(isPrivateCourse, GetUserToken(), courseName, courseDescription, GetUrlParam("organizationId"), defaultMaximumStudents, defaultMinimumStudents, "", price, courseStatus, courseType);
            axiosInstance.post("webportal/Course/AddCourse", obj);
        }
        else {
            const price = new Price(coursePrice, courseSale);
            const obj = new UpdateCourse(id, isPrivateCourse, GetUserToken(), courseName, courseDescription, defaultMaximumStudents, defaultMinimumStudents, "", price, courseStatus, courseType);
            axiosInstance.put("webportal/Course/UpdateCourse", obj)
        }
    }



    return (
        <Container component="main" maxWidth="xl">
            <PageName title={t("COURSE_TITLE_EDIT") + " - " + courseName} />
            <Paper>
                <AppBar position="static">
                    <Tabs value={valueTab} onChange={handleChangeTab} >
                        <Tab label={t("COURSE_TAB_BASIC_INFORMATION")} {...a11yProps(0)} />
                        <Tab label={t("COURSE_TAB_TERM")} {...a11yProps(1)} disabled={id === null} />
                        <Tab label={t("COURSE_TAB_MATERIAL")} {...a11yProps(2)} disabled={id === null} />

                    </Tabs>
                </AppBar>
                <TabPanel value={valueTab} index={0}>
                    <ValidatorForm className={classes.form}
                        onSubmit={saveBasicData}
                    >
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_NAME")}
                                    onChange={handleChangeCourseName}
                                    name="courseName"
                                    value={courseName}
                                    validators={['required']}
                                    errorMessages={[t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="courseName"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_DESCRIPTION")}
                                    onChange={handleChangeCourseDescription}
                                    name="courseDescription"
                                    value={courseDescription}
                                    variant="outlined"
                                    fullWidth
                                    id="courseDescription"
                                    rows={5}
                                    multiline={true}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <CustomCheckBox
                                    checked={isPrivateCourse}
                                    onChange={handleChangeIsPrivateCourse}
                                    name="isPrivateCourse"
                                    label={t("COURSE_IS_PRIVATE_COURSE")} />



                            </Grid>




                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_DEFAULT_MINIMUM_STUDENTS")}
                                    onChange={handleChangeDefaultMinimumStudents}
                                    name="defaultMinimumStudents"
                                    value={defaultMinimumStudents}
                                    variant="outlined"
                                    fullWidth
                                    id="defaultMinimumStudents"
                                    type="number"
                                    InputProps={{ inputProps: { min: 0, max: defaultMaximumStudents } }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_DEFAULT_MAXIMUM_STUDENTS")}
                                    onChange={handleChangeDefaultMaximumStudents}
                                    name="defaultMaximumStudents"
                                    value={defaultMaximumStudents}
                                    validators={['isValidStudenCount']}
                                    errorMessages={[t("VALIDATION_STUDENT_COUNT")]}
                                    variant="outlined"
                                    fullWidth
                                    id="defaultMaximumStudents"
                                    type="number"
                                    InputProps={{ inputProps: { min: defaultMinimumStudents } }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_PRICE")}
                                    onChange={handleChangeCoursePrice}
                                    validators={['isValidPrice']}
                                    errorMessages={[t("VALIDATION_PRICE")]}
                                    name="coursePrice"
                                    value={coursePrice}
                                    variant="outlined"
                                    fullWidth
                                    id="coursePrice"
                                    type="number"
                                    InputProps={{ inputProps: { min: 0 } }}

                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("COURSE_SALE")}
                                    onChange={handleChangeCourseSale}
                                    name="courseSale"
                                    validators={['isValidSale']}
                                    errorMessages={[t("VALIDATION_SALE")]}
                                    value={courseSale}
                                    variant="outlined"
                                    fullWidth
                                    id="courseSale"
                                    type="number"
                                    InputProps={{ inputProps: { min: 0, max: 100 } }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <CodeBook codeBookIdentificator="cb_coursetype" label={t("COURSE_TYPE")} id="courseType" value={courseType} onChange={handleChangeCourseType} autoTranslate={true} />
                            </Grid>
                            <Grid item xs={12}>
                                <CodeBook codeBookIdentificator="cb_coursestatus" label={t("COURSE_STATUS")} id="courseStatus" value={courseStatus} onChange={handleChangeCourseStatus} autoTranslate={true} />
                            </Grid>



                        </Grid>
                        <Button type="submit"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}>{t("COURSE_BASIC_INFORMATION_SAVE")}</Button>
                    </ValidatorForm>
                </TabPanel>
                <TabPanel value={valueTab} index={1}>
                    <CustomTable AddLinkUri={"/courseterm/add?courseId=" + id+"&organizationId="+GetUrlParam("organizationId")} AddLinkText={t("COURSE_TERM_BUTTON_ADD")} Columns={
                        [{ title: t("ORGANIZATION_BRANCH_NAME"), field: 'name' },
                        { title: t("ORGANIZATION_BRANCH_CITY"), field: 'city' },
                        { title: t("ORGANIZATION_BRANCH_HOUSE_NUMBER"), field: 'houseNumber' },
                        { title: t("ORGANIZATION_BRANCH_REGION"), field: 'region' },
                        { title: t("ORGANIZATION_BRANCH_STREET"), field: 'street' },
                        { title: t("ORGANIZATION_BRANCH_ZIP_CODE"), field: 'zipCode' },
                        { title: t("ORGANIZATION_BRANCH_COUNTRY_NAME"), field: 'countryName' },
                        ]
                    }
                        ShowAddButton={true}
                        ShowEdit={true}
                        ShowDelete={true}
                        Data={courseTerm}
                        EditLinkUri={"/courseterm/edit"}
                        EditLinkText={t("ORGANIZATION_BRANCH_EDIT")}
                        DeleteUrl={"webportal/CourseTerm​/DeleteCourseTerm"}
                        DeleteDialogTitle={t("ORGANIZATION_BRACH_DELETE_TITLE")}
                        DeleteDialogContent={t("ORGANIZATION_BRANCH_DELETE_CONTENT")}
                        DeleteParamIdName={"courseTermId"}
                        ReplaceContent={"name"}
                        DeleteButtonText={t("ORGANIZATION_BRANCH_DELETE")}
                    />
                </TabPanel>
                <TabPanel value={valueTab} index={2}>
                    <CustomTable AddLinkUri={"/organization/adduser?organizationId=" + id} AddLinkText={t("ORGANIZATION_ADD_USER")} Columns={
                        [{ title: t("ORGANIZATION_USER_FULL_NAME"), field: 'fullName' },
                        { title: t("ORGANIZATION_USER_EMAIL"), field: 'userEmail' },
                        { title: t("ORGANIZATION_USER_ROLE"), field: 'userRole' },
                        ]
                    }
                        ShowAddButton={true}
                        ShowEdit={true}
                        ShowDelete={true}
                        Data={[]}
                        EditLinkUri={"/organization/adduser"}
                        EditLinkText={t("ORGANIZATION_USER_EDIT")}
                        DeleteUrl={"webportal/OrganizationUser/DeleteUserFromOrganization"}
                        DeleteDialogTitle={t("ORGANIZATION_USER_DELETE_TITLE")}
                        DeleteDialogContent={t("ORGANIZATION_USER_DELETE_CONTENT")}
                        DeleteParamIdName={"userOrganizationId"}
                        ReplaceContent={"fullName"}
                        DeleteButtonText={t("ORGANIZATION_USER_DELETE")}
                    />
                </TabPanel>

            </Paper>


        </Container>
    );
}
CourseEdit.prototype = {
    cbCountry: PropTypes.any,
    cbAddressType: PropTypes.any
}





