import React from 'react';
import { FormControl, InputLabel, Select, MenuItem } from '@material-ui/core';
import PropTypes from 'prop-types';
import useStyles from '../../styles';

export default function CustomSelect(props:any) {
    const classes = useStyles();
    const {label,data,selectValue,onChangeValue,id,multiple} = props;
    return (
        <FormControl className={classes.formControl} variant="outlined" fullWidth  >
        <InputLabel id={id+"-label"}>{label}</InputLabel>
        <Select fullWidth multiple={multiple}
          labelId={id+"-label"}
          id={id} 
          value={selectValue}
          onChange={onChangeValue}
          label={label}>
          {data.map((e: any, keyIndex: any) => {
          return (<MenuItem key={keyIndex} value={e.id}>{e.name}</MenuItem>);
        })}
        </Select>
      </FormControl>
    );
  }
  CustomSelect.prototype ={
      label: PropTypes.string,
      data: PropTypes.array,
      selectValue: PropTypes.any,
      onChangeValue: PropTypes.func,
      id: PropTypes.string,
      multiple: PropTypes.bool
  }