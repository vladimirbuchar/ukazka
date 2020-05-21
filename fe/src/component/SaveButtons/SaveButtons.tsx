import React from 'react';
import { Box, Button } from '@material-ui/core';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';
import useStyles from '../../styles';
import {Link as ReactLink} from 'react-router-dom';
export default function SaveButtons(props: any) {
    const {backUrl,onSave} = props;
    const classes = useStyles();
    const { t } = useTranslation();
    return (<Box >
        <Button type="submit"
            variant="contained"
            color="primary"
            className={classes.submit}>{t("SAVE_BUTTON_SAVE")}</Button>
            <Button  component={ReactLink} to={backUrl} variant="contained" color="primary" className={classes.buttonSbmitPadding} onClick={onSave} >{t("SAVE_BUTTON_SAVE_AND_BACK")}</Button>
            <Button component={ReactLink} to={backUrl} variant="contained" color="primary" className={classes.buttonSbmitPadding}>{t("SAVE_BUTTON_BACK")}</Button>
    </Box>
    );
}
SaveButtons.prototype = {
    backUrl: PropTypes.string,
    onSave: PropTypes.func
}