import React, { useEffect } from 'react';
import { Container, Paper, AppBar, Tabs, Tab,  Grid, FormControl, InputLabel, Select, MenuItem, Chip, Button } from '@material-ui/core';
import PageName from '../../component/PageName/PageName';
import { useTranslation } from 'react-i18next';
import a11yProps from '../../component/A11yProps/A11yProps';
import TabPanel from '../../component/TabPanel/TabPanel';
import useStyles from '../../styles';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import { axiosInstance } from '../../axiosInstance';
import GetUserToken from '../../core/GetUserToken';
import GetUrlParam from '../../core/GetUrlParam';
import { InsertUserToOrganization } from '../../WebModel/OrganizationUser/InsertUserToOrganization';
import GetUserOrganizationRole from '../../core/GetUserOrganizationRole';
import OrganizationPermition from '../../WebModel/Shared/OrganizationPermition';
import { useHistory } from 'react-router';
import SaveButtons from '../../component/SaveButtons/SaveButtons';

export default function AddUserToOrganization() {
  const { t } = useTranslation();
  const [valueTab, setValueTab] = React.useState(0);
  const [userEmail, setUserEmail] = React.useState("");
  const [role, setRole] = React.useState("");
  const [roleList, setRoleList] = React.useState([]);
  const [userEmailsList, setUserEmailsList] = React.useState([]);
  const [id, setId] = React.useState("");
  const paramId = GetUrlParam("id");
  const [permitions, setPermitions] = React.useState(new OrganizationPermition(false, false, false, false, false, false))
  
  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue);
  };
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
  const classes = useStyles();
  const handleChangeRole = (e: any) => {
    setRole(e.target.value);
  }
  useEffect(() => {
    const fetchData = async () => {
      
      let permitions = await GetUserOrganizationRole(GetUserToken(), paramId ===""?GetUrlParam("organizationId"):paramId, paramId ===""?"organization":"userinorganization");
      setPermitions(permitions);
      if (paramId !== "") {
        setId(paramId);
      }
      
      await axiosInstance.get("webportal/OrganizationUser/GetOrganizationRoles").then(function (response) {

        const roleItems = response?.data?.data;
        const roleItemsMenuItems = roleItems.filter((x: any) => x.roleIndentificator !== "ORGANIZATION_OWNER").map((e: any, keyIndex: any) => {
          return (<MenuItem key={keyIndex} value={e.roleId}>{t(e.roleIndentificator)}</MenuItem>);
        });
        setRoleList(roleItemsMenuItems);
        if (paramId !== "") {
          axiosInstance.get("webportal/OrganizationUser/GetUserOrganizationRoleDetail", {
            params: {
              accessToken: GetUserToken(),
              userOrganizationId: paramId,
            }
          }).then(function (response2: any) {
            setRole(response2?.data?.data?.id);
          });
        }
      });

    }
    fetchData();
  }, []);
  
  const saveBasicData = () => {
    let id = GetUrlParam("id");
    if (id === "") {
      let emails: string[];
      emails =[];
      let i = 0;
      userEmailsList.forEach(function (item: any) {
        emails[i] = item.email;
        i++;
      });
      const addUser= new InsertUserToOrganization(emails,GetUrlParam("organizationId"),role,GetUserToken());
      axiosInstance.post("webportal/OrganizationUser/AddUserToOrganization", addUser);
    }
    else 
    {
      axiosInstance.put("webportal/OrganizationUser/UpdateUserInOrganizationRole", {
        organizationRoleId: role,
        id: id,
        userAccessToken: GetUserToken()
      });
    }
  }
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

  return (
    <Container component="main" maxWidth="xl">
      <PageName title={t("ADD_USER_TO_ORGANIZATION_TITLE")} />
      {!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
        <div>Přístup odepřen</div>
      }
      {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&<Paper>
        <AppBar position="static">
          <Tabs value={valueTab} onChange={handleChangeTab} aria-label="simple tabs example">
            <Tab label={t("ADD_USER_TO_ORGANIZATION_BATIC_INFORMATION")} {...a11yProps(0)} />
          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form}
            onSubmit={saveBasicData}>
            <Grid container spacing={2}>
              {id === "" && <Grid item xs={12}>
                <TextValidator
                  label={t("ADD_USER_TO_ORGANIZTION_USER_EMAILS")}
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


              </Grid>}
              <Grid item xs={12}>
                <FormControl className={classes.formControl} variant="outlined" fullWidth  >
                  <InputLabel id="role-label">{t("ADD_USER_TO_ORGANIZATION_ROLE")}</InputLabel>
                  <Select fullWidth
                    labelId="role-label"
                    id="role"
                    value={role}
                    onChange={handleChangeRole}
                    label={t("ADD_USER_TO_ORGANIZATION_ROLE")}>
                    {roleList}
                  </Select>
                </FormControl>
              </Grid>
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={"/organization/user/?id="+GetUrlParam("organizationId")+"&gototab=user"} />
          </ValidatorForm>
        </TabPanel>

      </Paper>
}
    </Container>
  );
}