import React from 'react';
import {  Snackbar } from '@material-ui/core';
import MuiAlert from '@material-ui/lab/Alert';
import PropTypes from 'prop-types';
import useStyles from '../../styles';
function Alert(props:any) {
    return <MuiAlert elevation={6} variant="filled" {...props} />;
  }

export default function CustomAlert(props:any) {
    const{open,onClose, message,severity } = props;
    const classes = useStyles();
    return (
      

      
        <Snackbar open={open} autoHideDuration={600000} onClose={onClose} className={classes.top} >
        <Alert onClose={onClose} severity={severity}>
          {message}
        </Alert>
      </Snackbar>
      
    );
  }
  CustomAlert.prototype ={
    open:PropTypes.string,
    onClose: PropTypes.func,
    severity: PropTypes.string,
    message: PropTypes.string
  }