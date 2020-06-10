import React, { useEffect } from 'react';
import { Container, AppBar, Tabs, Paper, Tab, Grid, Chip } from '@material-ui/core';
import PageName from '../../component/PageName/PageName';
import { useTranslation } from 'react-i18next';
import OrganizationPermition from '../../WebModel/Shared/OrganizationPermition';
import GetUrlParam from '../../core/GetUrlParam';
import GetUserToken from '../../core/GetUserToken';
import GetUserOrganizationRole from '../../core/GetUserOrganizationRole';
import a11yProps from '../../component/A11yProps/A11yProps';
import TabPanel from '../../component/TabPanel/TabPanel';
import useStyles from '../../styles';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import SaveButtons from '../../component/SaveButtons/SaveButtons';
import { axiosInstance } from '../../axiosInstance';

export default function AddStudentToTerm() {
    const classes = useStyles();
    const { t } = useTranslation();
    const paramId = GetUrlParam("id");
    const [userEmail, setUserEmail] = React.useState("");
    const [permitions, setPermitions] = React.useState(new OrganizationPermition(false, false, false, false, false, false))
    const [valueTab, setValueTab] = React.useState(0);
    const [userEmailsList, setUserEmailsList] = React.useState([]);
    const handleChangeTab = (event: any, newValue: any) => {
        setValueTab(newValue);
    };
    const handleDelete = (chipToDelete: any) => () => {

        let tmpArray = [] as any;
        let i = 0;
        userEmailsList.forEach(function (item: any) {
            if (item.email !== chipToDelete.email) {
                tmpArray[i] = { email: item.email }
                i++;
            }
        });
        setUserEmailsList(tmpArray);
    };
    const saveBasicData = () => {
        let emails: string[];
        emails = [];
        let i = 0;
        userEmailsList.forEach(function (item: any) {
            emails[i] = item.email;
            i++;
        });
        axiosInstance.post("webportal/CourseTermStudent/AddStudentToCourseTerm", {
            userEmail: emails,
            courseTermId: GetUrlParam("courseTermId"),
            userAccessToken: GetUserToken()
        })
    }
    const handleChangeEmail = (e: any) => {
        let value = e.target.value;
        if (value.endsWith(',')) {
            value = value.substring(0, value.length - 1)
            if (value !== "") {
                let tmpArray = [] as any;
                tmpArray = userEmailsList;
                let length = tmpArray.length;
                tmpArray[length] = { email: value };
                setUserEmailsList(tmpArray);
                setUserEmail("");
            }
        }
        else {
            setUserEmail(value);
        }
    }

    useEffect(() => {
        const fetchData = async () => {
            let permitions = await GetUserOrganizationRole(GetUserToken(), paramId === "" ? GetUrlParam("organizationId") : paramId, paramId === "" ? "organization" : "userinorganization");
            setPermitions(permitions);
        }
        fetchData();
    }, []);
    return (
        <Container component="main" maxWidth="xl">
            <PageName title={t("ADD_STUDENT_TO_TERM")} />
            {!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
                <div>Přístup odepřen</div>
            }
            {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) && <Paper>
                <AppBar position="static">
                    <Tabs value={valueTab} onChange={handleChangeTab} aria-label="simple tabs example">
                        <Tab label={t("ADD_STUDENT_TO_TERM_BASIC_INFORMATION")} {...a11yProps(0)} />
                    </Tabs>
                </AppBar>
                <TabPanel value={valueTab} index={0}>
                    <ValidatorForm className={classes.form}
                        onSubmit={saveBasicData}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("ADD_STUDENT_TO_COURSE_TERM")}
                                    onChange={handleChangeEmail}
                                    name="userEmail"
                                    value={userEmail}
                                    validators={['isEmail']}
                                    errorMessages={[t("VALIDATION_EMAIL")]}
                                    variant="outlined"
                                    fullWidth
                                    id="userEmail"
                                />
                                <Paper component="ul" className={classes.userEmails}>
                                    {userEmailsList.map((data: any) => {

                                        return (
                                            <li key={data.key}>
                                                <Chip
                                                    label={data.email}
                                                    onDelete={handleDelete(data)}
                                                    className={classes.chip}
                                                />
                                            </li>
                                        );
                                    })}

                                </Paper>


                            </Grid>

                        </Grid>
                        <SaveButtons onSave={saveBasicData} backUrl={"/courseterm/edit?id=" + GetUrlParam("courseTermId") + "&organizationId="+GetUrlParam("organizationId")} />
                    </ValidatorForm>
                </TabPanel>

            </Paper>
            }
        </Container>
    );
}