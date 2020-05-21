import React, { useState, useEffect } from 'react';
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
import PropTypes from 'prop-types';
import CustomTable from '../../component/CustomTable/CustomTable';
import PageName from '../../component/PageName/PageName';
import ContactField from '../../component/ContactField/ContactField';
import GetUrlParam from '../../core/GetUrlParam';
import AddressField from '../../component/AddressField/AddressField';
import GetUserToken from '../../core/GetUserToken';
import { AddBranch } from '../../WebModel/Branch/AddBranch';
import { ContactInformation } from '../../WebModel/Shared/ContactInformation';
import { Address } from '../../WebModel/Shared/Address';
import { UpdateBranch } from '../../WebModel/Branch/UpdateBranch';
import CustomCheckBox from '../../component/CustomCheckBox/CustomCheckBox';
import { GetCodeBookDefaultValue } from '../../core/GetCodeBookDefaultValue';
import GetUserOrganizationRole from '../../core/GetUserOrganizationRole';
import OrganizationPermition from '../../WebModel/Shared/OrganizationPermition';
import { useHistory } from 'react-router';
import SaveButtons from '../../component/SaveButtons/SaveButtons';
export default function BranchEdit(props: any) {
  const { cbCountry } = props;
  let { cbAddressType } = props;
  let id = GetUrlParam("id");
  const { t } = useTranslation();
  const classes = useStyles();
  const [valueTab, setValueTab] = React.useState(-1);
  const [branchName, setBranchName] = React.useState("");
  const [branchDescription, setBranchDescription] = React.useState("");
  const [country, setCountry] = useState("");
  const [region, setRegion] = useState("");
  const [city, setCity] = useState("");
  const [street, setStreet] = useState("");
  const [houseNumber, setHouseNumber] = useState("");
  const [zipCode, setZipCode] = useState("");
  const [contactEmail, setContactEmail] = React.useState("");
  const [contactPhone, setContactPhone] = React.useState("");
  const [contactWWW, setContactWWW] = React.useState("");
  const [isMainBranch, setIsMainBranch] = React.useState(false);
  const [classRooms, setClassRooms] = React.useState([]);
  const [permitions, setPermitions] = React.useState(new OrganizationPermition(undefined, undefined, undefined, undefined, undefined, undefined))
  const goToTab = GetUrlParam("gototab");

  const handleChangeIsMainBranch = (event: any) => {
    setIsMainBranch(event.target.checked)
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

  const handleChangeBranchName = (event: any) => {
    setBranchName(event.target.value);
  }
  const handleChangeBrnachDescription = (event: any) => {
    setBranchDescription(event.target.value);
  }
  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue);
  };

  const reloadClassRoom = async () => {
    setValueTab(1);
    await axiosInstance.get("webportal/ClassRoom/GetAllClassRoomInBranch", {
      params: {
        accessToken: GetUserToken(),
        branchId: id
      }
    }).then(function (response) {
      setClassRooms(response.data.data);
    });
  }

  useEffect(() => {
    const fetchData = async () => {
      if (goToTab === "classroom") {
        reloadClassRoom();
      }
      let permitions = await GetUserOrganizationRole(GetUserToken(), id === "" ? GetUrlParam("organizationId") : id, id === "" ? "organization" : "branch");
      setPermitions(permitions);

      if (cbAddressType.length === 0 || cbAddressType.length === undefined) {
        await axiosInstance.get("/shared/CodeBook/GetCodeBookItems/cb_addresstype").then(function (response) {
          cbAddressType = response.data.data;
        });
      }

      if (id === "") {
        const coutryId = await GetCodeBookDefaultValue("cb_country", cbCountry);
        setCountry(coutryId);
        setValueTab(0);
      }
      else {
        await axiosInstance.get("webportal/Branch/GetBranchDetail", {
          params: {
            accessToken: GetUserToken(),
            branchId: id
          }
        }).then(function (response: any) {
          const address = response?.data?.data?.address;
          setCity(_.get(address, "city", ""));
          setHouseNumber(_.get(address, "houseNumber", ""));
          setRegion(_.get(address, "region", ""));
          setZipCode(_.get(address, "zipCode", ""));
          setCountry(_.get(address, "countryId", ""));
          setStreet(_.get(address, "street", ""));
          setBranchName(response.data.data.name);
          setBranchDescription(response.data.data.description);
          setContactEmail(response.data.data.contactInformation.email);
          setContactPhone(response.data.data.contactInformation.phoneNumber);
          setContactWWW(response.data.data.contactInformation.www);
          setIsMainBranch(response.data.data.isMainBranch)
          if (goToTab === "") {
            setValueTab(0);
          }
        });
      }
    }
    fetchData();
  }, []);


  const saveBasicData = () => {
    const branchAddress = cbAddressType.find((x: any) => x.systemIdentificator === "BRANCH_ADDRESS");
    const branchAddressId = _.get(branchAddress, "id", "");
    const contactInformation = new ContactInformation(contactEmail, contactPhone, contactWWW);
    const adress = new Address(country, region, city, street, houseNumber, zipCode, branchAddressId);
    if (id === "") {
      const addBranch = new AddBranch(contactInformation, adress, isMainBranch, GetUserToken(), branchName, branchDescription, GetUrlParam("organizationId"));
      axiosInstance.post("webportal/Branch/AddBranch", addBranch);
    }
    else {
      const update = new UpdateBranch(contactInformation, adress, isMainBranch, GetUserToken(), branchName, branchDescription, id);
      axiosInstance.put("webportal/Branch/UpdateBranch", update);
    }
  }



  return (
    <Container component="main" maxWidth="xl">
      <PageName title={t("BRANCH_TITLE_EDIT") + " - " + branchName} />¨
      {!(permitions.isOrganizationOwner === true || permitions.isOrganizationAdministrator === true) &&
        <div>Přístup odepřen</div>
      }
      {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) && <Paper>
        <AppBar position="static">
          <Tabs value={valueTab} onChange={handleChangeTab} aria-label="simple tabs example">
            <Tab label={t("BRANCH_TAB_BASIC_INFORMATION")} {...a11yProps(0)} />
            <Tab label={t("BRANCH_TAB_CLASSROOM")} {...a11yProps(1)} disabled={id === ""} onClick={reloadClassRoom} />
          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form}
            onSubmit={saveBasicData}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>

                <TextValidator
                  label={t("BRANCH_NAME")}
                  onChange={handleChangeBranchName}
                  name="branchName"
                  value={branchName}
                  variant="outlined"
                  fullWidth
                  id="branchName"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("BRANCH_DESCRIPTION")}
                  onChange={handleChangeBrnachDescription}
                  name="branchDescription"
                  value={branchDescription}
                  variant="outlined"
                  fullWidth
                  id="branchDescription"
                  rows={5}
                  multiline={true}
                />

              </Grid>
              <Grid item xs={12}>
                <CustomCheckBox
                  checked={isMainBranch}
                  onChange={handleChangeIsMainBranch}
                  name="isMainBranch"
                  label={t("BRANCH_IS_MAIN_BRANCH")} />

              </Grid>
              <Grid item xs={12}>
                <Grid item xs={12}>
                  <Typography component="h1" variant="h5">
                    {t("BRANCH_ADDRESS")}
                  </Typography>
                </Grid>
                <AddressField idPrefix="" country={country} onChangeCountry={handleChangeCountry} region={region} onChangeRegion={handleChangeRegion}
                  city={city} onChangeCity={handleChangeCity} street={street} onChangeStreet={handleChangeStreet} houseNumber={houseNumber}
                  onChangeHouseNumber={handleChangeHouseNumber} zipCode={zipCode} onChangeZipCode={handleChangeZipCode} cbCountry={cbCountry} />
              </Grid>
              <Grid item xs={12}>
                <ContactField onChangeEmail={handleChangeContactEmail} email={contactEmail} onChangePhoneNumber={handleChangeContactPhone} phoneNumber={contactPhone}
                  onChangeWWW={handleChangeContactWWW} www={contactWWW}
                />
              </Grid>
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={"/organization/branch/?id=" + GetUrlParam("organizationId") + "&gototab=branch"} />
          </ValidatorForm>
        </TabPanel>
        <TabPanel value={valueTab} index={1}>

          <Container component="main" maxWidth="xl">
            <CustomTable AddLinkUri={"/classroom/add?branchId=" + id} AddLinkText={t("CLASSROOM_BUTTON_ADD")} Columns={
              [
                { title: t("BRANCH_CLASSROOM_NAME"), field: 'name' },
                { title: t("BRANCH_CLASSROOM_DESCRIPTION"), field: 'description' },
                { title: t("BRANCH_CLASSROOM_FLOOR"), field: 'floor' },
                { title: t("BRANCH_CLASSROOM_CAPACITY"), field: 'maxCapacity' }

              ]
            }
              ShowAddButton={true}
              EditParams={"&branchId=" + id}
              ShowEdit={true}
              ShowDelete={true}
              Data={classRooms}
              EditLinkUri={"/classroom/edit"}
              EditLinkText={t("BRANCH_CLASS_ROOM_EDIT")}
              DeleteUrl={"webportal/ClassRoom/DeleteClassRoom"}
              DeleteDialogTitle={t("BRANCH_CLASS_ROOM_DELETE_TITLE")}
              DeleteDialogContent={t("BRANCH_CLASS_ROOM_DELETE_CONTENT")}
              DeleteParamIdName={"classRoomId"}
              onReload={reloadClassRoom}
              ReplaceContent={"name"}
              DeleteButtonText={t("BRANCH_CLASS_ROOM_DELETE")}
            />


          </Container>
        </TabPanel>
      </Paper>
      }


    </Container>
  );
}
BranchEdit.prototype = {
  cbCountry: PropTypes.any,
  cbAddressType: PropTypes.any
}
