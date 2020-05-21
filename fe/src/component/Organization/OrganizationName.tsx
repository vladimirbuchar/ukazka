
import React from 'react';
import { useTranslation } from 'react-i18next';
import { Grid, Typography } from '@material-ui/core';
import PropTypes from 'prop-types';
export function OrganizationName(props: any) {
    const { t } = useTranslation();
    const { name, description, isOrganizationOwner } = props;
    return (
        <Grid item xs>
            <Typography component="h2" variant="h5">
                {name}
            </Typography>
            <Typography variant="body2" gutterBottom>
                {isOrganizationOwner && t("ORGANIZATION_OWNER")}
            </Typography>
            <Typography variant="body2" gutterBottom>
                {description}
            </Typography>
        </Grid>
    )
}
OrganizationName.propTypes = {
    name: PropTypes.string,
    description: PropTypes.string,
    isOrganizationOwner: PropTypes.bool
};