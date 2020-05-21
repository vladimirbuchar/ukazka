import React, { useEffect } from 'react';
import { FormControl, InputLabel, Select, MenuItem } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import PropTypes from 'prop-types';
import useStyles from '../../styles';
import { useTranslation } from 'react-i18next';
import { CodeBookItem } from '../../WebModel/Shared/CodeBookItem';


export default function CodeBook(props: any) {
    const { codeBookIdentificator, label, id, onChange, autoTranslate, data } = props;
    let { value } = props;
    const [dataSelectItems, setDataSelectItems] = React.useState([]);
    const { t } = useTranslation();
    const classes = useStyles();

    useEffect(() => {

        const fetchData = async () => {
            await axiosInstance.get("/shared/CodeBook/GetCodeBookItems/" + codeBookIdentificator).then(function (response) {
                const menuItems = response.data.data.map((e: CodeBookItem, keyIndex: number) => {
                    const translate = autoTranslate ? t(e.name) : e.name;
                    return (<MenuItem key={keyIndex} value={e.id}>{translate}</MenuItem>);
                });
                setDataSelectItems(menuItems)
            });
        }
        if (data?.length === undefined || data?.length === 0 ) {
            fetchData();
        }
        else {
            const menuItems = data.map((e: CodeBookItem, keyIndex: number) => {
                const translate = autoTranslate ? t(e.name) : e.name;
                return (<MenuItem key={keyIndex} value={e.id}>{translate}</MenuItem>);
            });
            setDataSelectItems(menuItems)
        }
    }, []);
    return (
        <FormControl className={classes.formControl} variant="outlined" fullWidth >
            <InputLabel id={id + "-label"}>{label}</InputLabel>
            <Select labelId={id + "-label"} id={id} value={value} onChange={onChange} label={label} fullWidth >
                {dataSelectItems}
            </Select>
        </FormControl>
    );
}
CodeBook.prototype = {
    codeBookIdentificator: PropTypes.string.isRequired,
    label: PropTypes.string,
    id: PropTypes.string,
    value: PropTypes.string,
    onChange: PropTypes.any,
    autoTranslate: PropTypes.bool,
    data: PropTypes.any
}