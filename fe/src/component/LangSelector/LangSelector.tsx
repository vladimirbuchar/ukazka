import React from 'react';
import { Button, Menu, MenuItem } from '@material-ui/core';
import data from  './LangSelector.config.json';
import {getLanguage,changeLanguage} from "./../../i18n";
import TranslateIcon from '@material-ui/icons/Translate';

export default function LangSelector() {
    const [anchorEl, setAnchorEl] = React.useState(null);
  
    const handleClick = (event: any) => {
      setAnchorEl(event.currentTarget);
    };
  
    const handleClose = () => {
        
      setAnchorEl(null);
    };
    const changeLanguageClick = (event :any) => {
        const { language } = event.currentTarget.dataset;
        changeLanguage(language);
        setAnchorEl(null);
      };
    const menuItem = data.map((item:any) =>
    {
        return (
            <MenuItem key={item.id} onClick={changeLanguageClick} data-language={item.id}>{item.name}</MenuItem>
        )
    });
    
    return (
      <div>
        <Button aria-controls="simple-menu" aria-haspopup="true" onClick={handleClick} color="inherit">
        <TranslateIcon />{data.find(x=> x.id === getLanguage())?.name}
        </Button>
        <Menu
          id="simple-menu"
          anchorEl={anchorEl}
          keepMounted
          open={Boolean(anchorEl)}
          onClose={handleClose}
        >
          {menuItem}
        </Menu>
      </div>
    );
  }