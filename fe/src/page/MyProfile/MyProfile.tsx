import React, { useState, useEffect } from 'react';
import { Container, Typography, AppBar, Tabs, Tab, Grid, Button, Paper } from '@material-ui/core';
import { useTranslation } from 'react-i18next';
import useStyles from '../../styles';
import { axiosInstance } from '../../axiosInstance';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import _ from 'lodash';
import DeleteIcon from '@material-ui/icons/Delete';
import TabPanel from '../../component/TabPanel/TabPanel';
import a11yProps from '../../component/A11yProps/A11yProps';
import PageName from '../../component/PageName/PageName';
import AddressField from '../../component/AddressField/AddressField';
import QuestionDialog from '../../component/QuestionDialog/QuestionDialog';
import PropTypes from 'prop-types';
import { UpdateUser } from '../../WebModel/User/UpdateUser';
import { Address } from '../../WebModel/Shared/Address';
import { Person } from '../../WebModel/Shared/Person';
import GetUserToken from '../../core/GetUserToken';
import GetUserId from '../../core/GetUserId';
import { ChangePassword } from '../../WebModel/User/ChangePassword';
import { GetCodeBookDefaultValue } from '../../core/GetCodeBookDefaultValue';

export default function MyProfile(props: any) {

    const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
    const { cbCountry } = props;
    let { cbAddressType } = props;

    const handleClickOpenDeleteDialog = () => {
        setOpenDeleteDialog(true);
    };

    const handleCloseDeleteDialog = () => {
        setOpenDeleteDialog(false);
    };
    const handleDeleteAccount = () => {
        axiosInstance.delete("webportal/User/DeleteUser", {
            params: {
                userId: window.sessionStorage.getItem("userId"),
                accessToken: GetUserToken()
            }
        }).then(function () {
            setOpenDeleteDialog(false);
            window.location.href = "/logout";
        });
    };
    const { t } = useTranslation();
    const classes = useStyles();
    const [value, setValue] = React.useState(0);
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [pernamentCountry, setPernamentCountry] = useState("");
    const [pernamentAddressRegion, setPernamentAddressRegion] = useState("");
    const [pernamentAddressCity, setPernamentAddressCity] = useState("");
    const [pernamentAddressStreet, setPernamentAddressStreet] = useState("");
    const [pernamentAddressHouseNumber, setPernamentAddressHouseNumber] = useState("");
    const [pernamentAddressZipCode, setPernamentAddressZipCode] = useState("");

    const [mailingCountry, setMailingCountry] = useState("");
    const [mailingAddressRegion, setMailingAddressRegion] = useState("");
    const [mailingAddressCity, setMailingAddressCity] = useState("");
    const [mailingAddressStreet, setMailingAddressStreet] = useState("");
    const [mailingAddressHouseNumber, setMailingAddressHouseNumber] = useState("");
    const [mailingAddressZipCode, setMailingAddressZipCode] = useState("");

    const [oldPassword, setOldPassword] = useState("");
    const [newPassword1, setNewPassword1] = useState("");
    const [newPassword2, setNewPassword2] = useState("");

    const handleChangePernamentCountry = (event: any) => {
        setPernamentCountry(event.target.value);
    };

    const handleChangeMailingCountry = (e: any) => {

        setMailingCountry(e.target.value);
    }
    const handleChangeMailingAddressRegion = (e: any) => {
        setMailingAddressRegion(e.currentTarget.value);
    }
    const handleChangeMailingAddressCity = (e: any) => {
        setMailingAddressCity(e.currentTarget.value);
    }
    const handleChangeMailingAddressStreet = (e: any) => {
        setMailingAddressStreet(e.currentTarget.value);
    }
    const handleChangeMailingAddressHouseNumber = (e: any) => {
        setMailingAddressHouseNumber(e.currentTarget.value);
    }
    const handleChangeMailingAddressZipCode = (e: any) => {
        setMailingAddressZipCode(e.currentTarget.value);
    }

    ValidatorForm.addValidationRule('isPasswordMatch', (value) => {
        if (newPassword1 !== newPassword2) {
            return false;
        }
        return true;
    });


    const handleChangeFirstName = (e: any) => {
        setFirstName(e.currentTarget.value);
    }
    const handleChangeLastName = (e: any) => {
        setLastName(e.currentTarget.value);
    }

    useEffect(() => {
        const fetchData = async () => {
            if (cbAddressType.length === 0 || cbAddressType.length === undefined) {
                await axiosInstance.get("/shared/CodeBook/GetCodeBookItems/cb_addresstype").then(function (response) {
                    cbAddressType = response.data.data;
                });
            }
            
            axiosInstance.get("/webportal/User/GetUserDetail", { params: { accessToken: GetUserToken(), userId: GetUserId() } })
                .then(async function (response) {
                    const defaultCountryId =  await GetCodeBookDefaultValue("cb_country",cbCountry);
                    setFirstName(response?.data?.data?.person?.firstName);
                    setLastName(response?.data?.data?.person?.lastName);
                    // pernament address
                    const cbPernamentAddress = cbAddressType.find((x: any) => x.systemIdentificator === "PERNAMENT_ADDRESS");
                    const cbMailingAddress = cbAddressType.find((x: any) => x.systemIdentificator === "MAILING_ADDRESS");
                    const cbPernamentAddressId = _.get(cbPernamentAddress, "id", "");
                    const cbMailingAddressId = _.get(cbMailingAddress, "id", "");
                    const address = response?.data?.data?.person?.address;
                    const pernamentAddress = address.find((x: any) => x.addressTypeId === cbPernamentAddressId);
                    const mailingAddress = address.find((x: any) => x.addressTypeId === cbMailingAddressId);

                    setPernamentAddressCity(_.get(pernamentAddress, "city", ""));
                    setPernamentAddressHouseNumber(_.get(pernamentAddress, "houseNumber", ""));
                    setPernamentAddressRegion(_.get(pernamentAddress, "region", ""));
                    setPernamentAddressZipCode(_.get(pernamentAddress, "zipCode", ""))
                    setPernamentCountry(_.get(pernamentAddress, "countryId", defaultCountryId))
                    setPernamentAddressStreet(_.get(pernamentAddress, "street", ""));

                    setMailingAddressCity(_.get(mailingAddress, "city", ""));
                    setMailingAddressHouseNumber(_.get(mailingAddress, "houseNumber", ""));
                    setMailingAddressRegion(_.get(mailingAddress, "region", ""));
                    setMailingAddressZipCode(_.get(mailingAddress, "zipCode", ""))
                    setMailingCountry(_.get(mailingAddress, "countryId", defaultCountryId))
                    setMailingAddressStreet(_.get(mailingAddress, "street", ""));
                    setValue(0);
                });
        };
        fetchData();
    }, []);

    const handleChange = (event: any, newValue: any) => {
        setValue(newValue);
    };

    const handleChangePernamentAddressRegion = (event: any) => {
        setPernamentAddressRegion(event.target.value);
    }
    const handleChangePernamentAddressCity = (event: any) => {
        setPernamentAddressCity(event.target.value);
    }
    const handleChangePernamentAddressStreet = (event: any) => {
        setPernamentAddressStreet(event.target.value);
    }
    const handleChangePernamentAddressHouseNumber = (event: any) => {
        setPernamentAddressHouseNumber(event.target.value);
    }
    const handleChangePernamentAddressZipCode = (event: any) => {
        setPernamentAddressZipCode(event.target.value);
    }

    const saveBasicData = () => {
        const pernamentAddress = cbAddressType.find((x: any) => x.systemIdentificator === "PERNAMENT_ADDRESS");
        const mailingAddress = cbAddressType.find((x: any) => x.systemIdentificator === "MAILING_ADDRESS");
        let addresses = [];
        addresses.push(new Address(pernamentCountry, pernamentAddressRegion, pernamentAddressCity, pernamentAddressStreet, pernamentAddressHouseNumber, pernamentAddressZipCode, _.get(pernamentAddress, "id", "")));
        addresses.push(new Address(mailingCountry, mailingAddressRegion, mailingAddressCity, mailingAddressStreet, mailingAddressHouseNumber, mailingAddressZipCode, _.get(mailingAddress, "id", "")));
        const person = new Person(firstName, "", lastName, addresses);
        const updateUser = new UpdateUser(GetUserId(), GetUserToken(), person);
        axiosInstance.put("webportal/User/UpdateUser", updateUser);
    }

    const handleChangePassword1 = (event: any) => {
        setNewPassword1(event.target.value);
    }
    const handleChangePassword2 = (event: any) => {
        setNewPassword2(event.target.value);
    }
    const handleChangeOldPassword = (event: any) => {
        setOldPassword(event.target.value);
    }
    const handleChangePasswordSubmit = () => {
        axiosInstance.put("webportal/User/ChangePassword", new ChangePassword(GetUserId(), oldPassword, newPassword1, newPassword2, GetUserToken()));
    }
    const logOutAllDevices = () => {
        axiosInstance.put("webportal/User/ChangeUserToken?accessToken=" + GetUserToken() + "&userId=" + GetUserId()).then(function () {
            window.location.href = "/logout";
        });
    }

    return (

        <Container component="main" maxWidth="xl">
            <PageName title={t("MY_PROFILE_TITLE")} />
            <Paper>
                <AppBar position="static">
                    <Tabs value={value} onChange={handleChange} aria-label="simple tabs example">
                        <Tab label={t("MY_PROFILE_BASIC_DATA")} {...a11yProps(0)} />
                        <Tab label={t("MY_PROFILE_CHANGE_PASSWORD")} {...a11yProps(1)} />
                        <Tab label={t("MY_PROFILE_OTHER_SETTINGS")} {...a11yProps(2)} />
                    </Tabs>
                </AppBar>
                <TabPanel value={value} index={0}>
                    <ValidatorForm className={classes.form}
                        onSubmit={saveBasicData}
                    >
                        <Grid container spacing={2}>
                            <Grid item xs={12} sm={6}>
                                <TextValidator
                                    label={t("MY_PROFILE_FIRST_NAME")}
                                    onChange={handleChangeFirstName}
                                    name="firstName"
                                    value={firstName}
                                    validators={['required']}
                                    errorMessages={[t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="firstName"
                                />
                            </Grid>
                            <Grid item xs={6}>
                                <TextValidator
                                    label={t("MY_PROFILE_LAST_NAME")}
                                    onChange={handleChangeLastName}
                                    name="lastName"
                                    value={lastName}
                                    validators={['required']}
                                    errorMessages={[t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="lastName"

                                />
                            </Grid>
                            <Grid item lg={6}>
                                <Grid item xs={12}>
                                    <Typography component="span" variant="body2">
                                        {t("MY_PROFILE_PERNAMENT_ADDRESS")}
                                    </Typography>
                                </Grid>
                                <AddressField idPrefix="pernament" country={pernamentCountry} onChangeCountry={handleChangePernamentCountry}
                                    region={pernamentAddressRegion} onChangeRegion={handleChangePernamentAddressRegion} city={pernamentAddressCity}
                                    onChangeCity={handleChangePernamentAddressCity} street={pernamentAddressStreet} onChangeStreet={handleChangePernamentAddressStreet}
                                    houseNumber={pernamentAddressHouseNumber} onChangeHouseNumber={handleChangePernamentAddressHouseNumber}
                                    zipCode={pernamentAddressZipCode} onChangeZipCode={handleChangePernamentAddressZipCode} cbCountry={cbCountry}
                                />
                            </Grid>

                            <Grid item lg={6}>
                                <Grid item xs={12}>
                                    <Typography component="span" variant="body2">
                                        {t("MY_PROFILE_MAILING_ADDRESS")}
                                    </Typography>
                                </Grid>
                                <AddressField idPrefix="mailiing" country={mailingCountry} onChangeCountry={handleChangeMailingCountry}
                                    region={mailingAddressRegion} onChangeRegion={handleChangeMailingAddressRegion} city={mailingAddressCity}
                                    onChangeCity={handleChangeMailingAddressCity} street={mailingAddressStreet} onChangeStreet={handleChangeMailingAddressStreet}
                                    houseNumber={mailingAddressHouseNumber} onChangeHouseNumber={handleChangeMailingAddressHouseNumber}
                                    zipCode={mailingAddressZipCode} onChangeZipCode={handleChangeMailingAddressZipCode} cbCountry={cbCountry}
                                />
                            </Grid>
                        </Grid>
                        <Button type="submit"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}>{t("MY_PROFILE_BASIC_INFORMATION_SAVE")}</Button>
                    </ValidatorForm>
                </TabPanel>

                <TabPanel value={value} index={1}>
                    <ValidatorForm className={classes.form} onSubmit={handleChangePasswordSubmit}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("MY_PROFILE_OLD_PASSWORD")}
                                    onChange={handleChangeOldPassword}
                                    name="oldPassword"
                                    value={oldPassword}
                                    validators={['required']}
                                    errorMessages={[t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="oldPassword"
                                    autoComplete="current-password"
                                    type="password"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("MY_PROFILE_NEW_PASSWORD")}
                                    onChange={handleChangePassword1}
                                    name="password"
                                    value={newPassword1}
                                    validators={['required']}
                                    errorMessages={[t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="password"
                                    autoComplete="current-password"
                                    type="password"
                                />

                            </Grid>
                            <Grid item xs={12}>
                                <TextValidator
                                    label={t("MY_PROFILE_NEW_PASSWORD2")}
                                    onChange={handleChangePassword2}
                                    name="repeatPassword"
                                    value={newPassword2}
                                    validators={['isPasswordMatch', 'required']}
                                    errorMessages={[t("VALIDATION_PASSWORD"), t("VALIDATION_REQUIRED")]}
                                    variant="outlined"
                                    fullWidth
                                    id="repeatPassword"
                                    autoComplete="current-password"
                                    type="password"
                                />
                            </Grid>
                        </Grid>
                        <Button type="submit"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}>{t("MY_PROFILE_CHANGE_PASSWORD_BUTTON")}</Button>
                    </ValidatorForm>

                </TabPanel>
                <TabPanel value={value} index={2}>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <Button type="button" onClick={logOutAllDevices} variant="contained" color="primary">
                                {t("MY_PROFILE_LOG_OUT_ALL_DEVICES")}
                            </Button>
                        </Grid>
                        <Grid item xs={12}>
                            <QuestionDialog content={t("MY_PROFILE_DELETE_DIALOG_CONTENT")} oclickYes={handleDeleteAccount} onCloseDialog={handleCloseDeleteDialog}
                                openDialog={openDeleteDialog} title={t("MY_PROFILE_DELETE_DIALOG_TITLE")} />
                            <Button type="button" onClick={handleClickOpenDeleteDialog} variant="contained" color="secondary" startIcon={<DeleteIcon />}>
                                {t("MY_PROFILE_DELETE_ACOUNT")}
                            </Button>
                        </Grid>
                    </Grid>
                </TabPanel>
            </Paper>
        </Container>
    );
}
MyProfile.prototype = {
    cbCountry: PropTypes.any,
    cbAddressType: PropTypes.any
}
