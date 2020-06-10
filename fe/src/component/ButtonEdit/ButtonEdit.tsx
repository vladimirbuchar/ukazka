import React, { forwardRef } from 'react';
import EditIcon from '@material-ui/icons/Edit';
import { Link as ReactLink } from "react-router-dom";
import useStyles from '../../styles';
import { Button } from '@material-ui/core';
import PropTypes from 'prop-types';
export function ButtonEdit(props: any) {
    const classes = useStyles();
    const { Text, Uri,fullWidth } = props;
    return (<Button
      fullWidth={fullWidth}
      variant="contained"
      color="primary"
      className={classes.button}
      startIcon={<EditIcon />}
      component={ReactLink} to={Uri}
    >
      {Text}
    </Button>)
  }
  ButtonEdit.prototype = {
    Text: PropTypes.string,
    Uri: PropTypes.string,
    fullWidth:PropTypes.bool
  }