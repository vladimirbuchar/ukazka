import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import _ from 'lodash';
import { Container, AppBar, Tabs, Tab, Paper } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import a11yProps from '../../component/A11yProps/A11yProps';
import TabPanel from '../../component/TabPanel/TabPanel';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import CustomTable from '../../component/CustomTable/CustomTable';
import PageName from '../../component/PageName/PageName';
import GetUrlParam from '../../core/GetUrlParam';
import GetUserToken from '../../core/GetUserToken';
import { AddOrganization } from '../../WebModel/Organization/AddOrganization';
import { ContactInformation } from '../../WebModel/Shared/ContactInformation';
import { Address } from '../../WebModel/Shared/Address';
import { UpdateOrganization } from '../../WebModel/Organization/UpdateOrganization';
import CustomCheckBox from '../../component/CustomCheckBox/CustomCheckBox';
import AddressField from '../../component/AddressField/AddressField';
import ContactField from '../../component/ContactField/ContactField';
import PropTypes from 'prop-types';
import { GetCodeBookDefaultValue } from '../../core/GetCodeBookDefaultValue';
import GetUserOrganizationRole from '../../core/GetUserOrganizationRole';
import OrganizationPermition from './../../WebModel/Shared/OrganizationPermition';
export default function OrganizationEdit(props: any) {
  const { t } = useTranslation();
  const [course, setCourse] = React.useState([]);
  const [bankOfQuestion, setBankOfQuestion] = React.useState([]);
  let id: string;
  const classes = useStyles();
  const [valueTab, setValueTab] = React.useState(0);
  const [organizatioName, setOrganizationName] = React.useState("");
  const [organizationDescription, setOrganizationDescription] = React.useState("");
  const [sendInquiryCourse, setSendInquiryCourse] = React.useState(false);
  let { cbCountry, cbAddressType } = props;
  const [country, setCountry] = useState("");
  const [region, setRegion] = useState("");
  const [city, setCity] = useState("");
  const [street, setStreet] = useState("");
  const [houseNumber, setHouseNumber] = useState("");
  const [zipCode, setZipCode] = useState("");
  const [countryContact, setCountryContact] = useState("");
  const [regionContact, setRegionContact] = useState("");
  const [cityContact, setCityContact] = useState("");
  const [streetContact, setStreetContact] = useState("");
  const [houseNumberContact, setHouseNumberContact] = useState("");
  const [zipCodeContact, setZipCodeContact] = useState("");
  const [branchInOrganization, setBranchInOrganization] = useState([]);
  const [userInOrganization, setUserInOrganization] = useState([]);
  const [contactEmail, setContactEmail] = React.useState("");
  const [contactPhone, setContactPhone] = React.useState("");
  const [contactWWW, setContactWWW] = React.useState("");
  const [permitions, setPermitions] = React.useState(new OrganizationPermition(false, false, false, false, false, false))
  const goToTab = GetUrlParam("gototab");
 
  id = GetUrlParam("id");

  const reloadUserInOrganization = async () => {
    setValueTab(2);
    axiosInstance.get("webportal/OrganizationUser/GetAllUserInOrganization", {
      params: {
        accessToken: GetUserToken(),
        organizationId: id
      }
    }).then(function (response: any) {
      let course = [] as any;
      response?.data?.data?.forEach(function (item: any) {
        course.push({
          id: item.id,
          naem: item.fullName,
          userEmail: item.userEmail,
          userRole: t(item.userRole),
          hideActionButton: item.userRole === "ORGANIZATION_OWNER"
        })
      });
      setUserInOrganization(course);
    });
  }
  const realoadBankOfQuestion = async ()=>
  {
    setValueTab(4);
    if (id !== "") {
      axiosInstance.get("webportal/BankOfQuestion/GetBankOfQuestionInOrganization", {
        params: {
          accessToken: GetUserToken(),
          organizationId: id
        }
      }).then(function (response: any) {
        setBankOfQuestion(response.data.data);

      })
    }
  }

  const reloadCourse = async () => {
    setValueTab(3);
    if (id !== "") {
      axiosInstance.get("webportal/Course/GetAllCourseInOrganization/", {
        params: {
          accessToken: GetUserToken(),
          organizationId: id
        }
      }).then(function (response: any) {
        setCourse(response.data.data);

      })
    }
  }

  const reloadBranch = async () => {
    setValueTab(1);
    if (id !== "") {

      axiosInstance.get("webportal/Branch/GetAllBranchInOrganization", {
        params: {
          accessToken: GetUserToken(),
          organizationId: id
        }
      }).then(function (response) {
        let org = [] as any;
        let i = 0;
        response.data.data.forEach(function (item: any) {
          const obj = {
            name: item.name,
            id: item.id,
            city: item.address.city,
            houseNumber: item.address.houseNumber,
            region: item.address.region,
            street: item.address.street,
            zipCode: item.address.zipCode,
            countryName: item.address.countryName
          }
          org[i] = obj;
          i++;
        });
        setBranchInOrganization(org);
      })
    }
  }

  const handleChangeContactEmail = (event: any) => {
    setContactEmail(event.target.value);
  }

  const handleChangeContactPhone = (event: any) => {
    setContactPhone(event.target.value);
  }

  const handleChangeContactWWW = (event: any) => {
    setContactWWW(event.target.value);
  }

  const handleChangeCountry = (e: any) => {
    setCountry(e.target.value);
  }

  const handleChangeStreet = (event: any) => {
    setStreet(event.target.value);
  }

  const handleChangeCity = (event: any) => {
    setCity(event.target.value);
  }

  const handleChangeRegion = (event: any) => {
    setRegion(event.target.value);
  }

  const handleChangeHouseNumber = (event: any) => {
    setHouseNumber(event.target.value);
  }

  const handleChangeZipCode = (event: any) => {
    setZipCode(event.target.value);
  }

  const handleChangeCountryContact = (e: any) => {
    setCountryContact(e.target.value);
  }

  const handleChangeStreetContact = (event: any) => {
    setStreetContact(event.target.value);
  }

  const handleChangeCityContact = (event: any) => {
    setCityContact(event.target.value);
  }

  const handleChangeRegionContact = (event: any) => {
    setRegionContact(event.target.value);
  }

  const handleChangeHouseNumberContact = (event: any) => {
    setHouseNumberContact(event.target.value);
  }

  const handleChangeZipCodeContact = (event: any) => {
    setZipCodeContact(event.target.value);
  }

  const handleChangeSendInquiryCourse = (event: any) => {
    setSendInquiryCourse(event.target.checked)
  }

  const handleChangeOrganizationName = (event: any) => {
    setOrganizationName(event.target.value);
  }

  const handleChangeOrganizationDescription = (event: any) => {
    setOrganizationDescription(event.target.value);
  }

  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue);
  }

  const reloadBasicData = async () => {

    if (cbAddressType.length === 0 || cbAddressType.length === undefined) {
      await axiosInstance.get("/shared/CodeBook/GetCodeBookItems/cb_addresstype").then(function (response) {
        cbAddressType = response.data.data;
      });
    }
    if (id !== "") {

      axiosInstance.get("webportal/Organization/GetOrganizationDetail", {
        params: {
          accessToken: GetUserToken(),
          organizationId: id
        }
      }).then(function (response: any) {

        const cbRegisteredOfficeAddress = cbAddressType.find((x: any) => x.systemIdentificator === "RegisteredOfficeAddress");
        const cbBillingAddress = cbAddressType.find((x: any) => x.systemIdentificator === "BillingAddress");
        const cbRegisteredOfficeAddressId = _.get(cbRegisteredOfficeAddress, "id", "");
        const cbBillingAddressId = _.get(cbBillingAddress, "id", "");
        const address = response?.data?.data?.addresses;
        const registeredOfficeAddress = address.find((x: any) => x.addressTypeId === cbRegisteredOfficeAddressId);
        const billingAddress = address.find((x: any) => x.addressTypeId === cbBillingAddressId);

        setCity(_.get(registeredOfficeAddress, "city", ""));
        setHouseNumber(_.get(registeredOfficeAddress, "houseNumber", ""));
        setRegion(_.get(registeredOfficeAddress, "region", ""));
        setZipCode(_.get(registeredOfficeAddress, "zipCode", ""))
        setCountry(_.get(registeredOfficeAddress, "countryId", ""))
        setStreet(_.get(registeredOfficeAddress, "street", ""));
        setCityContact(_.get(billingAddress, "city", ""));
        setHouseNumberContact(_.get(billingAddress, "houseNumber", ""));
        setRegionContact(_.get(billingAddress, "region", ""));
        setZipCodeContact(_.get(billingAddress, "zipCode", ""))
        setCountryContact(_.get(billingAddress, "countryId", ""))
        setStreetContact(_.get(billingAddress, "street", ""));
        setOrganizationName(response.data.data.name);
        setOrganizationDescription(response.data.data.description);
        setContactEmail(response.data.data.contactInformation.email);
        setContactPhone(response.data.data.contactInformation.phoneNumber);
        setContactWWW(response.data.data.contactInformation.www);
      });

    }
  }

  useEffect(() => {
    const fetchData = async () => {
      if (id === "") {
        setCountry(await GetCodeBookDefaultValue("cb_country", cbCountry));
        setCountryContact(await GetCodeBookDefaultValue("cb_country", cbCountry));
      }
      let permitions = await GetUserOrganizationRole(GetUserToken(), id, "organization");
      setPermitions(permitions);

      if (goToTab ==="branch") {
        reloadBranch();
        reloadBasicData();
      }
      else if (goToTab ==="course") {
        reloadCourse();
        reloadBasicData();
      }
      else if (goToTab ==="user")
      {
        reloadBasicData();
        reloadUserInOrganization();

      }
      else {
        reloadBasicData();
      }
    }
    fetchData();
  }, []);

  const saveBasicData = async () => {
    const addressOffice = cbAddressType.find((x: any) => x.systemIdentificator === "RegisteredOfficeAddress");
    const addressOfficeId = _.get(addressOffice, "id", "");

    const addressBilling = cbAddressType.find((x: any) => x.systemIdentificator === "BillingAddress");
    const addressBillingId = _.get(addressBilling, "id", "");
    let contactInformation = new ContactInformation(contactEmail, contactPhone, contactWWW);
    let addresses = [];

    addresses.push(new Address(country, region, city, street, houseNumber, zipCode, addressOfficeId));
    addresses.push(new Address(countryContact, regionContact, cityContact, streetContact, houseNumberContact, zipCodeContact, addressBillingId));
    if (id === "") {
      let obj = new AddOrganization(contactInformation, addresses, sendInquiryCourse, GetUserToken(), organizatioName, organizationDescription);
      axiosInstance.post("webportal/Organization/AddOrganization", obj);
    }
    else {
      let obj = new UpdateOrganization(id, contactInformation, addresses, sendInquiryCourse, GetUserToken(), organizatioName, organizationDescription);
      axiosInstance.put("webportal/Organization/UpdateOrganization", obj);
    }
  }



  return (
    <Container component="main" maxWidth="xl">
      {valueTab === -1 &&
        <PageName title="" />}
      {valueTab === 0 &&
        <PageName title={t("ORGANIZATION_TITLE_EDIT") + " - " + organizatioName} />}
      {valueTab === 1 &&
        <PageName title={t("ORGANIZATION_TITLE_BRANCH") + " - " + organizatioName} />}
      {valueTab === 2 &&
        <PageName title={t("ORGANIZATION_TITLE_USERS") + " - " + organizatioName} />}
      {valueTab === 3 &&
        <PageName title={t("ORGANIZATION_TITLE_COURSE") + " - " + organizatioName} />}
        {valueTab === 4 &&
        <PageName title={t("ORGANIZATION_TITLE_BANK_OF_QUESTION") + " - " + organizatioName} />}
      <Paper>
        <AppBar position="static">
          <Tabs value={valueTab} onChange={handleChangeTab} >
            <Tab label={t("ORGANIZATION_TAB_BASIC_INFORMATION")} {...a11yProps(0)} disabled={!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator)} className={!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) ? classes.dn : ""} />
            <Tab label={t("ORGANIZATION_TAB_BRANCH")} {...a11yProps(1)} disabled={id === "" || !(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator)} onClick={reloadBranch} className={!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) ? classes.dn : ""} />
            <Tab label={t("ORGANIZATION_TAB_USERS")} {...a11yProps(2)} disabled={id === "" || !(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator)} onClick={reloadUserInOrganization} className={!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) ? classes.dn : ""} />
            <Tab label={t("ORGANIZATION_COURSE")} {...a11yProps(3)} disabled={id === ""} onClick={reloadCourse} />
            <Tab label={t("ORGANIZATION_BANK_OF_QUESTION")} {...a11yProps(4)} disabled={id === ""} onClick={realoadBankOfQuestion} />
          </Tabs>
        </AppBar>
        {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
          <TabPanel value={valueTab} index={0}>
            <ValidatorForm className={classes.form} onSubmit={saveBasicData}>
              <Grid container spacing={2}>
                <Grid item xs={12}>

                  <TextValidator
                    label={t("ORGNIZATION_NAME")}
                    onChange={handleChangeOrganizationName}
                    name="organizatioName"
                    value={organizatioName}
                    validators={['required']}
                    errorMessages={[t("VALIDATION_REQUIRED")]}
                    variant="outlined"
                    fullWidth
                    id="organizatioName"
                  />
                </Grid>
                <Grid item xs={12}>
                  <TextValidator
                    label={t("ORGNIZATION_DESCRIPTION")}
                    onChange={handleChangeOrganizationDescription}
                    name="organizationDescription"
                    value={organizationDescription}
                    variant="outlined" fullWidth
                    id="organizationDescription"
                    rows={5}
                    multiline={true}
                  />
                </Grid>
                <Grid item xs={12}>
                  <CustomCheckBox onChange={handleChangeSendInquiryCourse} checked={sendInquiryCourse} name="sendInquiryCourse" label={t("ORGNIZATION_SEND_INQUIRY_COURSE")} />
                </Grid>
                <Grid item xs={6}>
                  <Grid item xs={12}>
                    <Typography component="h1" variant="h5">
                      {t("ORGANIZATION_MAIN_BRANCH")}
                    </Typography>
                  </Grid>
                  <AddressField idPrefix="" country={country} onChangeCountry={handleChangeCountry} region={region} onChangeRegion={handleChangeRegion}
                    city={city} onChangeCity={handleChangeCity} street={street} onChangeStreet={handleChangeStreet} houseNumber={houseNumber}
                    onChangeHouseNumber={handleChangeHouseNumber} zipCode={zipCode} onChangeZipCode={handleChangeZipCode} cbCountry={cbCountry} />

                </Grid>

                <Grid item xs={6}>
                  <Grid item xs={12}>
                    <Typography component="h1" variant="h5">
                      {t("ORGANIZATION_MAIN_BRANCH_CONTACT")}
                    </Typography>
                  </Grid>
                  <AddressField idPrefix="contact" country={countryContact} onChangeCountry={handleChangeCountryContact} region={regionContact} onChangeRegion={handleChangeRegionContact}
                    city={cityContact} onChangeCity={handleChangeCityContact} street={streetContact} onChangeStreet={handleChangeStreetContact} houseNumber={houseNumberContact}
                    onChangeHouseNumber={handleChangeHouseNumberContact} zipCode={zipCodeContact} onChangeZipCode={handleChangeZipCodeContact} cbCountry={cbCountry} />

                </Grid>
                <Grid item xs={12}>
                  <ContactField onChangeEmail={handleChangeContactEmail} email={contactEmail} onChangePhoneNumber={handleChangeContactPhone}
                    phoneNumber={contactPhone} onChangeWWW={handleChangeContactWWW} www={contactWWW} />
                </Grid>


              </Grid>
              <Button type="submit"
                fullWidth
                variant="contained"
                color="primary"
                className={classes.submit}>{t("ORGANIZATION_BASIC_INFORMATION_SAVE")}</Button>
            </ValidatorForm>
          </TabPanel>
        }
        {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
          <TabPanel value={valueTab} index={1}>
            <CustomTable AddLinkUri={"/branch/add?organizationId=" + id} AddLinkText={t("BRANCH_BUTTON_ADD")} Columns={
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
              Data={branchInOrganization}
              EditLinkUri={"/branch/edit"}
              EditParams={"organizationId=" + id}
              EditLinkText={t("ORGANIZATION_BRANCH_EDIT")}
              DeleteUrl={"webportal/Branch/DeleteBranch"}
              DeleteDialogTitle={t("ORGANIZATION_BRACH_DELETE_TITLE")}
              DeleteDialogContent={t("ORGANIZATION_BRANCH_DELETE_CONTENT")}
              DeleteParamIdName={"branchId"}
              onReload={reloadBranch}
              ReplaceContent={"name"}
              DeleteButtonText={t("ORGANIZATION_BRANCH_DELETE")}
            />
          </TabPanel>
        }
        {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
          <TabPanel value={valueTab} index={2}>
            <CustomTable AddLinkUri={"/organization/adduser?organizationId=" + id} AddLinkText={t("ORGANIZATION_ADD_USER")} Columns={
              [{ title: t("ORGANIZATION_USER_FULL_NAME"), field: 'fullName' },
              { title: t("ORGANIZATION_USER_EMAIL"), field: 'userEmail' },
              { title: t("ORGANIZATION_USER_ROLE"), field: 'userRole' },
              ]
            }
              ShowAddButton={true}
              EditParams={"organizationId=" + id}
              ShowEdit={true}
              ShowDelete={true}
              Data={userInOrganization}
              EditLinkUri={"/organization/adduser"}
              EditLinkText={t("ORGANIZATION_USER_EDIT")}
              DeleteUrl={"webportal/OrganizationUser/DeleteUserFromOrganization"}
              DeleteDialogTitle={t("ORGANIZATION_USER_DELETE_TITLE")}
              DeleteDialogContent={t("ORGANIZATION_USER_DELETE_CONTENT")}
              DeleteParamIdName={"userOrganizationId"}
              onReload={reloadUserInOrganization}
              ReplaceContent={"fullName"}
              DeleteButtonText={t("ORGANIZATION_USER_DELETE")}
            />
          </TabPanel>
        }
        <TabPanel value={valueTab} index={3}>
          <CustomTable AddLinkUri={"/course/add?organizationId=" + id} AddLinkText={t("ORGANIZATION_COURSE_ADD")} Columns={
            [{ title: t("ORGANIZATION_COURSE_NAME"), field: 'name' },]
          }
            ShowAddButton={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator)}
            ShowEdit={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator || permitions.isCourseEditor)}
            ShowDelete={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator)}
            Data={course}
            EditLinkUri={"/course/edit"}
            EditLinkText={t("ORGANIZATION_COURSE_EDIT")}
            DeleteUrl={"webportal/Course/DeleteCourse"}
            DeleteDialogTitle={t("ORGANIZATION_COURSE_DELETE_TITLE")}
            DeleteDialogContent={t("ORGANIZATION_COURSE_DELETE_CONTENT")}
            DeleteParamIdName={"courseId"}
            onReload={reloadCourse}
            ReplaceContent={"name"}
            DeleteButtonText={t("ORGANIZATION_COURSE_DELETE")}
            EditParams={"organizationId="+GetUrlParam("id")}
          />
        </TabPanel>
        
        <TabPanel value={valueTab} index={4}>
          <CustomTable AddLinkUri={"/bankofquestion/add?organizationId=" + id} AddLinkText={t("ORGANIZATION_BANK_OF_QUESTION_ADD")} Columns={
            [{ title: t("ORGANIZATION_BANK_OF_QUESATION_NAME"), field: 'name' },]
          }
            ShowAddButton={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator)}
            ShowEdit={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator || permitions.isCourseEditor)}
            ShowDelete={(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator || permitions.isCourseAdministrator)}
            Data={bankOfQuestion}
            EditLinkUri={"/bankofquestion/edit"}
            EditLinkText={t("ORGANIZATION_BANK_OF_QUESTION_EDIT")}
            DeleteUrl={"webportal/BankOfQuestion/DeleteBankOfQuestion"}
            DeleteDialogTitle={t("ORGANIZATION_BANK_OF_QUESTION_DELETE_TITLE")}
            DeleteDialogContent={t("ORGANIZATION_BANK_OF_QUESTION_DELETE_CONTENT")}
            DeleteParamIdName={"bankOfQuestionId"}
            onReload={realoadBankOfQuestion}
            ReplaceContent={"name"}
            DeleteButtonText={t("ORGANIZATION_BANK_OF_QUESTION_DELETE")}
            EditParams={"bankOfQuestionId="+GetUrlParam("id")}
          />
        </TabPanel>
      </Paper>


    </Container>
  );
}
OrganizationEdit.prototype = {
  cbCountry: PropTypes.any,
  cbAddressType: PropTypes.any
}

