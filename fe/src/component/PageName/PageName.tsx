import React from 'react';
import {  Typography,  Box } from '@material-ui/core';
import PropTypes from 'prop-types';
import useStyles from '../../styles';
export default function PageName(props: any) {
  const{title} = props;
  const classes = useStyles();
    return (
      <Box className={classes.pageTitle}>
      <Typography component="h1" variant="h6">
      {title}
        
      </Typography>
      </Box>
    );
  }
  PageName.propTypes={
    title: PropTypes.string

  }