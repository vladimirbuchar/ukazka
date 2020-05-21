import React,{  ChangeEvent,  useState } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import { Link as ReactLink}  from "react-router-dom";
import { Container } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import CustomAlert from '../../component/CustomAlert/CustomAlert';

 
function SignIn() {
  const { t } = useTranslation();
  const classes = useStyles();
  const [openError, setOpenError] = React.useState(false);


  const [userName,setUserName] = useState("");
  const [userPassword,setUserPassword] = useState("");

  const onHandleUserName = (e: ChangeEvent<HTMLInputElement>) => {
    setUserName(e.currentTarget.value);
  };
  const onHandlePassword = (e: ChangeEvent<HTMLInputElement>) => {
    setUserPassword(e.currentTarget.value);
  };
  const onLogin = (e:any)=>
  {
    
    axiosInstance.get("web/User/GetUserToken",{params:{UserEmail: userName, UserPassword:userPassword}})
    .then(function (response) {
      if (response?.status === 200)
      {
        window.sessionStorage.setItem("userToken",response?.data?.data?.token);
        window.sessionStorage.setItem("userId",response?.data?.data?.id);
        window.location.href="/dashboard";
      }else 
      {
          setOpenError(true);
      }
      
      
      
    })
    e.preventDefault(false); 
  }
  const handleClose = (event:any, reason:any) => {
    if (reason === 'clickaway') {
      return;
    }

    setOpenError(false);
  };
  
 return (
  <Container component="main" maxWidth="xs">
      <div className={classes.paper}>
      <CustomAlert open={openError} onClose={handleClose} severity="error" message={t("SIGNIN_BAD_LOGIN")}/>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
        {t("SIGN_IN")}
        </Typography>
        <form className={classes.form} noValidate  onSubmit={onLogin}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="email"
            label={t("EMAIL_ADDRESS")}
            name="email"
            autoComplete="email"
            autoFocus
            onChange={onHandleUserName}
          />
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            name="password"
            label={t("PASSWORD")}
            type="password"
            id="password"
            autoComplete='off'
            value={userPassword}
            onChange={onHandlePassword}
          />
          <FormControlLabel
            control={<Checkbox value="remember" color="primary" />}
            label={t("REMEMBER_ME")}
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            disabled={userName ==="" || userPassword === ""}
          >
            {t("SIGN_IN_BUTTON")}
          </Button>
          <Grid container>
            <Grid item xs>
              <Link href="#" variant="body2">
              {t("FORGOT_PASSWORD")}
              </Link>
            </Grid>
            <Grid item>
              <Link  component={ReactLink} to="/signup" variant="body2">
                {t("SIGN_UP")}
              </Link>
            </Grid>
          </Grid>
        </form>
      </div>
</Container>
  );
}
export default SignIn
