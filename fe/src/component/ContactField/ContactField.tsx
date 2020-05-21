import React from 'react';
import {  Grid } from '@material-ui/core';
import { TextValidator } from 'react-material-ui-form-validator';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

export default function ContactField(props: any) {
    const {onChangeEmail, email,onChangePhoneNumber, phoneNumber, onChangeWWW,www} = props;
    const { t } = useTranslation();
    return (
        <Grid container spacing={2}>
            <Grid item xs={12}>
                <TextValidator
                  label={t("CONTACT_FIELD_EMAIL")}
                  onChange={onChangeEmail}
                  name="email"
                  value={email}
                  variant="outlined"
                  fullWidth
                  id="email"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("CONTACT_FIELD_PHONE")}
                  onChange={onChangePhoneNumber}
                  name="phoneNumber"
                  value={phoneNumber}
                  variant="outlined"
                  fullWidth
                  id="phoneNumber"
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t("CONTACT_FIELD_WWW")}
                  onChange={onChangeWWW}
                  name="www"
                  value={www}
                  variant="outlined"
                  fullWidth
                  id="www"
                />
              </Grid>
            
        </Grid>
    );
  }
  ContactField.prototype={
    onChangeEmail: PropTypes.func,
    email: PropTypes.string,
    onChangePhoneNumber: PropTypes.func,
    phoneNumber: PropTypes.string,
    onChangeWWW: PropTypes.func,
    www: PropTypes.string
  }