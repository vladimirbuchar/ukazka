import React, { useState } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { useTranslation } from 'react-i18next';
import useStyles from '../../styles';
import { Container } from '@material-ui/core';
import { Link as ReactLink}  from "react-router-dom";
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import { axiosInstance } from '../../axiosInstance';

export default function SignUp() {
  const { t } = useTranslation();
  const [email, setEmail] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [password1, setPassword1] = useState("");
  const [password2, setPassword2] = useState("");

  const classes = useStyles();
  const handleSubmit = () => {
    axiosInstance.post("web/User/AddUser",{
      userPassword: password1, userPassword2:password2,userEmail:email,person:{
      firstName:firstName,lastName:lastName
    }}).then(function(response:any){
      alert("aaabbb");
      console.log(response);
    });
    return false;
  }
  const handleChange = (e: any) => {
    setEmail(e.currentTarget.value);
  }
  const handleChangeFirstName = (e: any) => {
    setFirstName(e.currentTarget.value);
  }
  const handleChangeLastName = (e: any) => {
    setLastName(e.currentTarget.value);
  }
  const handleChangePassword1 = (e: any) => {
    setPassword1(e.currentTarget.value);
  }

  const handleChangePassword2 = (e: any) => {
    setPassword2(e.currentTarget.value);
  }
  ValidatorForm.addValidationRule('isPasswordMatch', (value) => {
    if (password1 !== password2) {
        return false;
    }
    return true;
});

  return (
    <Container component="main" maxWidth="md">

      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          {t("SIGN_UP_TITLE")}
      </Typography>
       
          <ValidatorForm className={classes.form}
            onSubmit={handleSubmit}
          >
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextValidator
                  label={t("SIGN_UP_FIRST_NAME")}
                  onChange={handleChangeFirstName}
                  name="firstName"
                  value={firstName}
                  validators={['required']}
                  errorMessages={[t("VALIDATION_REQUIRED")]}
                  variant="outlined"
                  fullWidth
                  id="firstName"
                  autoComplete="fname"
                  autoFocus
                />

              </Grid>
              <Grid item xs={12} sm={6}>
             <TextValidator
                  label={t("SIGN_UP_LAST_NAME")}
                  onChange={handleChangeLastName}
                  name="lastName"
                  value={lastName}
                  validators={['required']}
                  errorMessages={[t("VALIDATION_REQUIRED")]}
                  variant="outlined"
                  fullWidth
                  id="lastName"
                  autoComplete="lname"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("SIGN_UP_EMAIL_ADDRESS")}
                  onChange={handleChange}
                  name="email"
                  value={email}
                  validators={['required', 'isEmail']}
                  errorMessages={[t("VALIDATION_REQUIRED"), t("VALIDATION_EMAIL")]}
                  variant="outlined"
                  fullWidth
                  id="email"
                  autoComplete="email"
                />

              </Grid>
              <Grid item xs={12}>
              <TextValidator
                  label={t("SIGN_UP_PASSWORD")}
                  onChange={handleChangePassword1}
                  name="password"
                  value={password1}
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
                  label={t("SIGN_UP_PASSWORD_AGAIN")}
                  onChange={handleChangePassword2}
                  name="repeatPassword"
                  value={password2}
                  validators={['isPasswordMatch','required']}
                  errorMessages={[t("VALIDATION_PASSWORD"),t("VALIDATION_REQUIRED")]}
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
            className={classes.submit}>{t("SIGN_UP_SUBMIT_BUTTON")}</Button>


            <Grid container justify="flex-end">
              <Grid item>
              <Link  component={ReactLink} to="/" variant="body2">
                {t("SIGN_UP_LINK_TO_SIGN_IN")}
              </Link>
                
              </Grid>
            </Grid>
          </ValidatorForm>
   
      </div>

    </Container>

  );
}