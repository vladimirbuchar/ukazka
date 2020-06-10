import React, { useEffect } from 'react';
import {  Badge, Button } from '@material-ui/core';
import NotificationsIcon from '@material-ui/icons/Notifications';
import { axiosInstance } from '../../axiosInstance';
import { Link } from 'react-router-dom';
import GetUserToken from '../../core/GetUserToken';

export default function Notification() {
  const [notificationCount, setNotificationCount] = React.useState(0);

  const loadNotifications = async () => {
    if (GetUserToken() !== "") {
      axiosInstance.get("webportal/Notification/GetMyNewNotification", {
        params: {
          accessToken: GetUserToken()
        }
      }).then(function (response) {
        setNotificationCount(response.data.data.length);
      });
    }
  }
  setInterval(function () { loadNotifications(); }, 100000);
  const resetNotification = () => {
    setNotificationCount(0)
  }

  useEffect(() => {
    const fetchData = async () => {
      loadNotifications();
    }
    fetchData();
  }, []);
  return (
    <Button color="inherit" component={Link} to={"/notifications"} onClick={resetNotification} >
      <Badge badgeContent={notificationCount} color="secondary"  >
        <NotificationsIcon />
      </Badge>

    </Button>
  
  );
}