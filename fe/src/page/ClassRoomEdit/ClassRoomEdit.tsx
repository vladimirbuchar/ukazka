import React, { useEffect } from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import { Container, AppBar, Tabs, Paper, Tab } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import TabPanel from '../../component/TabPanel/TabPanel';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import PageName from '../../component/PageName/PageName';
import a11yProps from '../../component/A11yProps/A11yProps';
import GetUserToken from '../../core/GetUserToken';
import GetUrlParam from '../../core/GetUrlParam';
import { ClassRoomUpdate } from '../../WebModel/ClassRoom/ClassRoomUpdate';
import { ClassRoomAdd } from '../../WebModel/ClassRoom/ClassRoomAdd';
import GetUserOrganizationRole from '../../core/GetUserOrganizationRole';
import OrganizationPermition from '../../WebModel/Shared/OrganizationPermition';
import { useHistory } from 'react-router';
import SaveButtons from '../../component/SaveButtons/SaveButtons';
export default function BranchEdit() {
  let id = GetUrlParam("id");
  const { t } = useTranslation();
  const classes = useStyles();
  const [valueTab, setValueTab] = React.useState(-1);
  const [classRoomName, setClassRoomName] = React.useState("");
  const [classRoomDescription, setClassRoomDescription] = React.useState("");
  const [floor, setFloor] = React.useState(0);
  const [maxCapacity, setMaxCapacity] = React.useState(0);
  const [permitions, setPermitions] = React.useState(new OrganizationPermition(false, false, false, false, false, false))

  const handleChangeClassRoomName = (event: any) => {
    setClassRoomName(event.target.value);
  }
  const handleChangeClassRoomDescription = (event: any) => {
    setClassRoomDescription(event.target.value);
  }

  const handleChangeFloor = (event: any) => {
    setFloor(event.target.value);
  }
  const handleChangeMaxCapacity = (event: any) => {
    setMaxCapacity(event.target.value);
  }

  useEffect(() => {
    const fetchData = async () => {
      let permitions = await GetUserOrganizationRole(GetUserToken(), id ===""?GetUrlParam("branchId"):id, id ===""?"branch":"classroom");
      setPermitions(permitions);
      if (id === "") {
        setValueTab(0);
      }
      else {
        await axiosInstance.get("webportal/ClassRoom/GetClassRoomDetail", {
          params: {
            accessToken: GetUserToken(),
            classRoomId: id
          }
        }).then(function (response: any) {
          setClassRoomName(response.data.data.name);
          setClassRoomDescription(response.data.data.description);
          setFloor(response.data.data.floor);
          setMaxCapacity(response.data.data.maxCapacity);
          setValueTab(0);
        });
      }
    }
    fetchData();
  }, []);
 

  const saveBasicData = () => {
    let token = GetUserToken();
    let branchId = GetUrlParam("branchId");
    if (id === "") {
      const obj = new ClassRoomAdd(floor, maxCapacity, classRoomName, classRoomDescription, token, branchId);
      axiosInstance.post("webportal/ClassRoom/AddClassRoom", obj)
    }
    else {
      const obj = new ClassRoomUpdate(floor, maxCapacity, classRoomName, classRoomDescription, token, id);
      axiosInstance.put("webportal/ClassRoom/UpdateClassRoom", obj)
    }
  }



  return (
    <Container component="main" maxWidth="xl">
      <PageName title={t("CLASS_ROOM_TITLE_EDIT") + " - " + classRoomName} />
      {!(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&
        <div>Přístup odepřen</div>
      }
      {(permitions.isOrganizationOwner || permitions.isOrganizationAdministrator) &&<Paper>
        <AppBar position="static">
          <Tabs value={valueTab} aria-label="simple tabs example">
            <Tab label={t("CLASS_ROOM_BASIC_DATA")} {...a11yProps(0)} />
          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form} onSubmit={saveBasicData}>
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextValidator
                  label={t("CLASS_ROOM_NAME")}
                  onChange={handleChangeClassRoomName}
                  name="classRoomName"
                  value={classRoomName}
                  variant="outlined"
                  fullWidth
                  id="classRoomName"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("CLASS_ROOM_DESCRIPTION")}
                  onChange={handleChangeClassRoomDescription}
                  name="classRoomDescription"
                  value={classRoomDescription}
                  variant="outlined"
                  fullWidth
                  id="classRoomDescription"
                  rows={5}
                  multiline={true}
                />

              </Grid>

              <Grid item xs={12}>
                <TextValidator
                  label={t("CLASS_ROOM_FLOOR")}
                  onChange={handleChangeFloor}
                  name="floor"
                  value={floor}
                  variant="outlined"
                  fullWidth
                  id="floor"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("CLASS_ROOM_CAPACITY")}
                  onChange={handleChangeMaxCapacity}
                  name="maxCapacity"
                  value={maxCapacity}
                  variant="outlined"
                  fullWidth
                  id="maxCapacity"
                />
              </Grid>
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={"/branch/edit/?id="+GetUrlParam("branchId")+"&gototab=classroom"} />
          </ValidatorForm>
        </TabPanel>
    </Paper>}
    </Container>
  );
}