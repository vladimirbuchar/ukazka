import React, { useState, useEffect } from 'react';
import Grid from '@material-ui/core/Grid';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import { Container, AppBar, Tabs, Tab, Paper, TextField } from '@material-ui/core';
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
import CoursePrice from '../../component/CoursePrice/CoursePrice';
import SaveButtons from '../../component/SaveButtons/SaveButtons';
import CourseStudentCount from '../../component/CourseStudentCount/CourseStudentCount';
import CustomDatePicker from '../../component/CustomDatePicker/CustomDatePicker';
import CustomSelect from '../../component/CustomSelect/CustomSelect';
import CustomCheckBox from '../../component/CustomCheckBox/CustomCheckBox';
import { AddCourseTerm } from '../../WebModel/CourseTerm/AddCourseTerm';



export default function CourseTermEdit() {
    const { t } = useTranslation();
    var id = GetUrlParam("id");
    const classes = useStyles();
    const [valueTab, setValueTab] = React.useState(0);
    const [coursePrice, setCoursePrice] = useState(0);
    const [courseSale, setCourseSale] = useState(0);
    const [defaultMinimumStudents, setDefaultMinimumStudents] = useState(0);
    const [defaultMaximumStudents, setDefaultMaximumStudents] = useState(0);
    const [registrationFrom, setRegistrationFrom] = useState(new Date());
    const [registrationTo, setRegistrationTo] = useState(new Date());
    const [courseTermFrom, setCourseTermFrom] = useState(new Date());
    const [courseTermTo, setCourseTermTo] = useState(new Date());
    const [branch, setBranch] = useState("");
    const [branchList, setBranchList] = useState([]);
    const [classRoom, setClassRoom] = useState("");
    const [classRoomList, setClassRoomList] = useState([]);
    const [courseTimeFrom, setCourseTimeFrom] = useState("");
    const [courseTimeTo, setCourseTimeTo] = useState("");
    const [monday, setMonday] = useState(false);
    const [tuesday, setTuesday] = useState(false);
    const [wednesday,setWednesday] = useState(false);
    const [thursday,setThursday] = useState(false);
    const [friday,setFriday] = useState(false);
    const [saturday,setSaturday] = useState(false);
    const [sunday,setSunday] = useState(false);
    const [lectorList, setLectorList] = useState([]);
    const [lectors, setLectors] = useState([]);
    const handleChangeLector = (event:any) => {
        setLectors(event.target.value as never[]);
      };

    const handleChangeMonday = (event: any) => {
        setMonday(event.target.checked);
    }
    const handleChangeTuesday = (event: any) => {
        setTuesday(event.target.checked);
    }
    const handleChangeWednesday = (event: any) => {
        setWednesday(event.target.checked);
    }
    const handleChangeThursday = (event: any) => {
        setThursday(event.target.checked);
    }
    const handleChangeFriday = (event: any) => {
        setFriday(event.target.checked);
    }
    const handleChangeSaturday = (event: any) => {
        setSaturday(event.target.checked);
    }
    const handleChangeSunday = (event: any) => {
        setSunday(event.target.checked);
    }


    const handleChangeCourseTimeFrom = (event: any) => {
        setCourseTimeFrom(event.target.value);
    }
    const handleChangeCourseTimeTo = (event: any) => {
        setCourseTimeTo(event.target.value);
    }

    const handleChangeClassRoom = (event: any) => {
        setClassRoom(event.target.value);
    }

    const handleChangeBranch = (event: any) => {
        setBranch(event.target.value);
        axiosInstance.get("webportal/ClassRoom/GetAllClassRoomInBranch", {
            params: {
                accessToken: GetUserToken(),
                branchId: event.target.value
            }
        }).then(function (response: any) {
            let classRoom = [] as any;
            response.data.data.forEach((element: any) => {
                const obj = {
                    name: element.name,
                    id: element.id
                };
                classRoom.push(obj);
            });
            setClassRoomList(classRoom);
        });
    }

    const handleCourseTermToChange = (date: Date) => {
        setCourseTermTo(date);
    }
    const handleCourseTermFromChange = (date: Date) => {
        setCourseTermFrom(date);
    }

    const handleRegistrationFromChange = (date: Date) => {
        setRegistrationFrom(date);
    };
    const handleRegistrationToChange = (date: Date) => {
        setRegistrationTo(date);
    };

    const handleChangeCoursePrice = (event: any) => {
        setCoursePrice(event.target.value as number);
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

    const handleChangeTab = (event: any, newValue: any) => {
        setValueTab(newValue);
    }


    useEffect(() => {
        const fetchData = async () => {
            await axiosInstance.get("webportal/Branch/GetAllBranchInOrganization", {
                params: {
                    accessToken: GetUserToken(),
                    organizationId: GetUrlParam("organizationId")
                }
            }).then(function (response: any) {
                let branch = [] as any;
                response.data.data.forEach((element: any) => {
                    const obj = {
                        name: element.name,
                        id: element.id
                    };
                    branch.push(obj);
                });
                setBranchList(branch);
            });

           await axiosInstance.get("webportal/OrganizationUser/GetAllUserInOrganization", {
                params: {
                  accessToken: GetUserToken(),
                  organizationId: GetUrlParam("organizationId")
                }
              }).then(function (response: any) {
                let lector = [] as any;
                
                response?.data?.data?.filter((x:any)=> x.userRole === "LECTOR").forEach(function (item: any) {
                    lector.push({
                    id: item.id,
                    name: item.userEmail
                  });
                });

                setLectorList(lector);
              });

            if (id === "") {
                setValueTab(0);
                await axiosInstance.get("webportal/Course/GetCourseDetail", {
                    params: {
                        accessToken: GetUserToken(),
                        courseId: GetUrlParam("courseId")
                    }
                }).then(function (response: any) {
                    setCourseSale(response.data.data.coursePrice.sale);
                    setCoursePrice(response.data.data.coursePrice.price);
                    setValueTab(0);
                });
            }
            else {
                await axiosInstance.get("webportal/CourseTerm/GetCourseTermDetail", {
                    params: {
                        accessToken: GetUserToken(),
                        courseId: id
                    }
                }).then(function (response: any) {
                    setCourseSale(response.data.data.coursePrice.sale);
                    setCoursePrice(response.data.data.coursePrice.price);
                    setValueTab(0);
                });

            }
        }
        fetchData();
    }, []);

    const saveBasicData = () => {
        if (id === "") {
            const price = new Price(coursePrice, courseSale);
            const obj = new AddCourseTerm(GetUrlParam("courseId"),price,courseTermFrom,courseTermTo,registrationFrom,registrationTo,defaultMinimumStudents,
            defaultMaximumStudents,classRoom,monday,tuesday,wednesday,thursday,friday,saturday,sunday,courseTimeFrom,courseTimeTo,GetUserToken(),"","");
            console.log(obj);
              axiosInstance.post("webportal/CourseTerm/AddCourseTerm", obj);
        }
        else {
            const price = new Price(coursePrice, courseSale);
            /*const obj = new UpdateCourse(id, isPrivateCourse, GetUserToken(), courseName, courseDescription, defaultMaximumStudents, defaultMinimumStudents, "", price, courseStatus, courseType);
            axiosInstance.put("webportal/Course/UpdateCourse", obj)*/
        }
    }



    return (
        <Container component="main" maxWidth="xl">
            <PageName title={t("COURSE_TERM_TITLE_EDIT")} />
            <Paper>
                <AppBar position="static">
                    <Tabs value={valueTab} onChange={handleChangeTab} >
                        <Tab label={t("COURSE_TERM_TAB_BASIC_INFORMATION")} {...a11yProps(0)} />
                        <Tab label={t("COURSE_TERM_TAB_STUDENTS")} {...a11yProps(1)} disabled={id === null} />
                    </Tabs>
                </AppBar>
                <TabPanel value={valueTab} index={0}>
                    <ValidatorForm className={classes.form}
                        onSubmit={saveBasicData}
                    >
                        <Grid container spacing={2}>
                            <Grid item xs={6}>
                                <CustomSelect label={t("COURSE_TERM_BRANCH")} data={branchList} selectValue={branch} onChangeValue={handleChangeBranch} id="branch" />
                            </Grid>
                            <Grid item xs={6}>
                                <CustomSelect label={t("COURSE_TERM_CLASS_ROOM")} data={classRoomList} selectValue={classRoom} onChangeValue={handleChangeClassRoom} id="classRoom" />
                            </Grid>

                            <CourseStudentCount minimum={defaultMinimumStudents} maximum={defaultMaximumStudents} onChangeMinimum={handleChangeDefaultMinimumStudents} onChangeMaximum={handleChangeDefaultMaximumStudents} />
                            <CoursePrice price={coursePrice} sale={courseSale} onChangePrice={handleChangeCoursePrice} onChangeSale={handleChangeCourseSale} />

                            <Grid item xs={6}>
                                <CustomDatePicker selectedDate={registrationFrom} onChangeDate={handleRegistrationFromChange} label={t("COURSE_TERM_REGISTRATION_FROM")} />
                            </Grid>
                            <Grid item xs={6}>
                                <CustomDatePicker selectedDate={registrationTo} onChangeDate={handleRegistrationToChange} label={t("COURSE_TERM_REGISTRATION_TO")} />
                            </Grid>
                            <Grid item xs={6}>
                                <CustomDatePicker selectedDate={courseTermFrom} onChangeDate={handleCourseTermFromChange} label={t("COURSE_TERM_TERM_FROM")} />
                            </Grid>
                            <Grid item xs={6}>
                                <CustomDatePicker selectedDate={courseTermTo} onChangeDate={handleCourseTermToChange} label={t("COURSE_TERM_TERM_TO")} />
                            </Grid>
                            <Grid item xs={6}>
                                <CodeBook codeBookIdentificator="cb_timetable" label={t("COURSE_TERM_TIME_START")} id="timeFrom" value={courseTimeFrom} onChange={handleChangeCourseTimeFrom} />
                            </Grid>
                            <Grid item xs={6}>
                                <CodeBook codeBookIdentificator="cb_timetable" label={t("COURSE_TERM_TIME_END")} id="timeTo" value={courseTimeTo} onChange={handleChangeCourseTimeTo} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={monday} onChange={handleChangeMonday} label={t("COURSE_TERM_MONDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={tuesday} onChange={handleChangeTuesday} label={t("COURSE_TERM_TUESDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={wednesday} onChange={handleChangeWednesday} label={t("COURSE_TERM_WEDNESDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={thursday} onChange={handleChangeThursday} label={t("COURSE_TERM_THURSDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={friday} onChange={handleChangeFriday} label={t("COURSE_TERM_FRIDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={saturday} onChange={handleChangeSaturday} label={t("COURSE_TERM_SATURDAY")} />
                            </Grid>
                            <Grid item xs={2}>
                                <CustomCheckBox checked={sunday} onChange={handleChangeSunday} label={t("COURSE_TERM_SUNDAY")} />
                            </Grid>
                            <Grid item xs={12}>
                                <CustomSelect label={t("COURSE_LECTORS")} data={lectorList} selectValue={lectors} onChangeValue={handleChangeLector} id="lector" multiple={true} />

                            </Grid>



                        </Grid>
                        <SaveButtons />
                    </ValidatorForm>
                </TabPanel>
                <TabPanel value={valueTab} index={1}>
                    <CustomTable AddLinkUri={"/courseterm/add?courseId=" + id} AddLinkText={t("COURSE_TERM_BUTTON_ADD")} Columns={
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
                        Data={[]}
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
            </Paper>


        </Container>
    );
}
CourseTermEdit.prototype = {
    cbCountry: PropTypes.any,
    cbAddressType: PropTypes.any
}





