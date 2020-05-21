import React from 'react';
import {  Typography } from '@material-ui/core';
import useStyles from '../../styles';

export default function CompanyName() {
    const classes = useStyles();
    return (
    <Typography component="h1" variant="h6" color="inherit" noWrap className={classes.title}>
        FlexiLearning
      </Typography>
    );
  }