import React, { useEffect } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect,
} from "react-router-dom";
import clsx from 'clsx';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import Box from '@material-ui/core/Box';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import Container from '@material-ui/core/Container';
import MenuIcon from '@material-ui/icons/Menu';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import { UnLoggedUserItems, AboutUsItems, LogedUserItems } from './component/Menu/Menu';
import SignIn from './page/SignIn/SignIn';
import SignUp from './page/SignUp/SignUp';
import LangSelector from './component/LangSelector/LangSelector';
import Notification from './component/Notification/Notification';
import useStyles from './styles';
import Copyright from './component/Copyright/Copyright';
import CompanyName from './component/CompanyName/CompanyName';
import AboutUs from './page/AboutUs/AboutUs';
import Dashboard from './page/Dashboard/Dashboard';
import LogOut from './page/LogOut/LogOut';
import MyProfile from './page/MyProfile/MyProfile';
import OrganizationEdit from './page/OrganizationEdit/OrganizationEdit';
import OrganizationList from './page/OrganizationList/OrganizationList';
import BranchEdit from './page/BranchEdit/BranchEdit';
import ClassRoomEdit from './page/ClassRoomEdit/ClassRoomEdit';
import AddUserToOrganization from './page/AddUserToOrganization/AddUserToOrganization';
import NotificationList from './page/NotificationList/NotificationList';
import CourseEdit from './page/CourseEdit/CourseEdit';
import { axiosInstance } from './axiosInstance';
import GetUserToken from './core/GetUserToken';
import CourseTermEdit from './page/CourseTermEdit/CourseTermEdit';

export default function App() {

  const [cbCountry, setCbCountry] = React.useState([]);
  const [cbAddressType, setCbAddressType] = React.useState([]);

  useEffect(() => {
    const fetchData = async () => {
      axiosInstance.get("/shared/CodeBook/GetCodeBookItems/cb_country").then(function (response) {
        setCbCountry(response.data.data);
      });
      axiosInstance.get("/shared/CodeBook/GetCodeBookItems/cb_addresstype").then(function (response) {
        setCbAddressType(response.data.data);
      });
    }
    fetchData();
  }, []);
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);
  const handleDrawerOpen = () => {
    setOpen(true);
  };
  const handleDrawerClose = () => {
    setOpen(false);
  };
  let leftMenu;
  if (window.sessionStorage.getItem("userId") === null) {
    leftMenu = <UnLoggedUserItems />;
  }
  else {
    leftMenu = <LogedUserItems />;
  }


  return (
    <div className={classes.root}>
      <Router>
        <CssBaseline />
        <AppBar position="absolute" className={clsx(classes.appBar, open && classes.appBarShift)}>
          <Toolbar className={classes.toolbar}>
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={handleDrawerOpen}
              className={clsx(classes.menuButton, open && classes.menuButtonHidden)}
            >
              <MenuIcon />
            </IconButton>
            <CompanyName />
            {GetUserToken()!=="" &&
              <Notification />
            }
            <LangSelector />
          </Toolbar>
        </AppBar>
        <Drawer
          variant="permanent"
          classes={{
            paper: clsx(classes.drawerPaper, !open && classes.drawerPaperClose),
          }}
          open={open}
        >
          <div className={classes.toolbarIcon}>
            <IconButton onClick={handleDrawerClose}>
              <ChevronLeftIcon />
            </IconButton>
          </div>
          <Divider />
          {leftMenu}
          <Divider />
          <AboutUsItems />

        </Drawer>

        <main className={classes.content}>
          <div className={classes.appBarSpacer} />
          <Container component="main" maxWidth="xl">


            <Switch>
              <Route exact path="/">
                <SignIn />
              </Route>
              <Route path="/signup">
                <SignUp />
              </Route>
              <Route path="/aboutproduct">
                <AboutUs />
              </Route>
              {GetUserToken() !== "" && <Route exact path="/dashboard">
                <Dashboard />
              </Route>}
              
              {GetUserToken() !== "" && <Route path="/logout">
                <LogOut />
              </Route>}
              {GetUserToken() !== "" && <Route path="/myprofile">
                <MyProfile cbCountry={cbCountry} cbAddressType={cbAddressType} />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/add">
                <OrganizationEdit cbCountry={cbCountry} cbAddressType={cbAddressType}/>
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/edit">
                <OrganizationEdit cbCountry={cbCountry} cbAddressType={cbAddressType} />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/course">
                <OrganizationEdit cbCountry={cbCountry} cbAddressType={cbAddressType} />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/user">
                <OrganizationEdit cbCountry={cbCountry} cbAddressType={cbAddressType} />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/branch">
                <OrganizationEdit cbCountry={cbCountry} cbAddressType={cbAddressType} />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/adduser">
                <AddUserToOrganization />
              </Route>}
              {GetUserToken() !== "" && <Route path="/organization/list">
                <OrganizationList />
              </Route>}
              {GetUserToken() !== "" && <Route path="/branch/add">
                < BranchEdit cbCountry={cbCountry} cbAddressType={cbAddressType}/>
              </Route>}
              {GetUserToken() !== "" && <Route path="/branch/edit">
                < BranchEdit cbCountry={cbCountry} cbAddressType={cbAddressType}/>
              </Route>}

              {GetUserToken() !== "" && <Route path="/classroom/add">
                <ClassRoomEdit />
              </Route>}
              {GetUserToken() !== "" && <Route path="/classroom/edit">
                <ClassRoomEdit />
              </Route>}

              {GetUserToken() !== "" && <Route path="/notifications">
                <NotificationList />
              </Route>}

              {GetUserToken() !== "" && <Route path="/notifications">
                <NotificationList />
              </Route>}
              {GetUserToken() !== "" &&<Route path="/course/add">
                <CourseEdit />
              </Route>}
              {GetUserToken() !== "" &&<Route path="/course/edit">
                <CourseEdit />
              </Route>}

              {GetUserToken() !== "" &&<Route path="/courseterm/add">
                <CourseTermEdit />
              </Route>}
              {GetUserToken() !== "" &&<Route path="/courseterm/edit">
                <CourseTermEdit />
              </Route>}
              
              {GetUserToken() === "" &&
              <Route path='*' exact={true} component={Redirect} to="/" />
              }
              {GetUserToken() !== "" &&
              <Route path='*' exact={true} component={Redirect} to="/dashboard" />
              }


            </Switch>

            <Box mt={8}>
              <Copyright />
            </Box>
          </Container>
        </main>
      </Router>
    </div>
  );
}