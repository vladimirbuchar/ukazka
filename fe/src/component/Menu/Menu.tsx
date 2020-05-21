import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import PersonIcon from '@material-ui/icons/Person';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import Lock from '@material-ui/icons/Lock';
import AttachMoneyIcon from '@material-ui/icons/AttachMoney';
import EmailIcon from '@material-ui/icons/Email';
import HelpIcon from '@material-ui/icons/Help';
import InfoIcon from '@material-ui/icons/Info';
import BusinessIcon from '@material-ui/icons/Business';
import SchoolIcon from '@material-ui/icons/School';
import { Link } from "react-router-dom";
import { List } from '@material-ui/core';
import { useTranslation } from 'react-i18next';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import DashboardIcon from '@material-ui/icons/Dashboard';



export  function UnLoggedUserItems  (){
  const { t } = useTranslation();
  return (
    <List>
  <div>
  <ListSubheader inset>{t("MENU_UN_LOGGINED_USER")}</ListSubheader>
    <ListItem button component={Link} to="/">
      <ListItemIcon>
        <Lock />
      </ListItemIcon>
      <ListItemText primary={t("MENU_SIGN_IN")} />
      
    </ListItem>
    <ListItem button component={Link} to="/signup">
      <ListItemIcon>
        <PersonAddIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_SIGN_UP")} />
    </ListItem>
    
  </div>
  </List>
  )}
export function LogedUserItems () {
  const { t } = useTranslation();
  return (
    <List>
  <div>
    <ListSubheader inset>MY NAME</ListSubheader>
    <ListItem button component={Link} to="/dashboard">
      <ListItemIcon>
        <DashboardIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_DASHBOARD")} />
    </ListItem>
    <ListItem button component={Link} to="/myprofile">
      <ListItemIcon>
        <PersonIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_MY_PROFILE")} />
    </ListItem>
    <ListItem button component={Link} to="/organization/list">
      <ListItemIcon>
        <BusinessIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_MY_ORGANIZATIONS")} />
    </ListItem>
    <ListItem button>
      <ListItemIcon>
        <SchoolIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_MY_COURSES")} />
    </ListItem>
    <ListItem button component={Link} to="/logout">
      <ListItemIcon>
        <ExitToAppIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_LOG_OUT")} />
    </ListItem>
  </div>
  </List>)
}

export function AboutUsItems (){
  const { t } = useTranslation();
  return (
    <List>
  <div>
    <ListSubheader inset>{t("MENU_ABOUT_US")}</ListSubheader>
    <ListItem button component={Link} to="/aboutproduct">
      <ListItemIcon>
        <InfoIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_ABOUT_PRODUCT")} />
    </ListItem>

    <ListItem button>
      <ListItemIcon>
        <AttachMoneyIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_ABOUT_PRICE")} />
    </ListItem>
    <ListItem button>
      <ListItemIcon>
        <EmailIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_ABOUT_CONTACT")}/>
    </ListItem>
    <ListItem button>
      <ListItemIcon>
        <HelpIcon />
      </ListItemIcon>
      <ListItemText primary={t("MENU_ABOUT_HELP")} />
    </ListItem>
  </div>
  </List>
)};