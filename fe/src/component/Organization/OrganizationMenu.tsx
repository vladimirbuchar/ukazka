import React from 'react';
import { useTranslation } from 'react-i18next';
import { axiosInstance } from '../../axiosInstance';
import GetUserToken from '../../core/GetUserToken';
import { Container, ListItem, ListItemIcon, ListItemText } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import SchoolIcon from '@material-ui/icons/School';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import { Link as ReactLink } from "react-router-dom";
import BusinessIcon from '@material-ui/icons/Business';
import QuestionDialog from '../QuestionDialog/QuestionDialog';
import PropTypes from 'prop-types';
export function OrganizationMenu(props: any) {
    const { t } = useTranslation();
    const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
    const [openLeaveDialog, setOpenLeaveDeleteDialog] = React.useState(false);
    const { name, id, isOrganizationOwner, onDelete, userInOrganizationId,  isOrganizationAdministrator,  } = props;
    const handleDeleteOrganization = () => {
        axiosInstance.delete("webportal/Organization/DeleteOrganization", {
            params: {
                organizationId: id,
                accessToken: GetUserToken()
            }
        }).then(function () {
            onDelete();
            setOpenDeleteDialog(false);
        });
    };

    const handleLeaveUserFromOrganization = () => {
        axiosInstance.delete("webportal/OrganizationUser/DeleteUserFromOrganization", {
            params: {
                accessToken: GetUserToken(),
                userOrganizationId: userInOrganizationId
            }
        }).then(function () {
            onDelete();
            setOpenLeaveDeleteDialog(false);
        });
    };



    const handleClickOpenDeleteDialog = () => {
        setOpenDeleteDialog(true);
    };

    const handleCloseDeleteDialog = () => {
        setOpenDeleteDialog(false);
    };


    const handleClickOpenLeaveDialog = () => {
        setOpenLeaveDeleteDialog(true);
    };

    const handleCloseLeaveDialog = () => {
        setOpenLeaveDeleteDialog(false);
    };
    const editLink = "/organization/edit/?id=" + id;
    const branchLink = "/organization/branch/?id=" + id + "&gototab=branch";
    const courseLink = "/organization/course/?id=" + id + "&gototab=course";
    return (
        <Container component="main" maxWidth="xl">

            {(isOrganizationOwner || isOrganizationAdministrator) &&
                <ListItem button component={ReactLink} to={editLink}>
                    <ListItemIcon>
                        <EditIcon />
                    </ListItemIcon>
                    <ListItemText primary={t("ORGANIZATION_EDIT")} />
                </ListItem>
            }
            <ListItem button component={ReactLink} to={courseLink}>
                <ListItemIcon>
                    <SchoolIcon />
                </ListItemIcon>
                <ListItemText primary={t("ORGANIZATION_COURSE")} />
            </ListItem>
            {(isOrganizationOwner || isOrganizationAdministrator) &&
                <ListItem button component={ReactLink} to={branchLink}>
                    <ListItemIcon>
                        <BusinessIcon />
                    </ListItemIcon>
                    <ListItemText primary={t("ORGANIZATION_BRANCH")} />
                </ListItem>
            }
            {!isOrganizationOwner && <ListItem button onClick={handleClickOpenLeaveDialog}>
                <ListItemIcon>
                    <ExitToAppIcon />
                </ListItemIcon>
                <ListItemText primary={t("ORGANIZATION_LEAVE")} />
            </ListItem>
            }
            {isOrganizationOwner &&
                <ListItem button onClick={handleClickOpenDeleteDialog}>

                    <ListItemIcon>
                        <DeleteIcon />
                    </ListItemIcon>
                    <ListItemText primary={t("ORGANIZATION_DELETE")} />
                </ListItem>
            }
            {openDeleteDialog && <QuestionDialog content={t("ORGANIZATION_DELETE_CONTENT").replace("{name}", name)}
                oclickYes={handleDeleteOrganization}
                onCloseDialog={handleCloseDeleteDialog}
                openDialog={openDeleteDialog}
                title={t("ORGANIZATION_DELETE_TITLE")} />
            }
            {openLeaveDialog && <QuestionDialog content={t("ORGANIZATION_LEAVE_CONTENT").replace("{name}", name)}
                oclickYes={handleLeaveUserFromOrganization}
                onCloseDialog={handleCloseLeaveDialog}
                openDialog={openLeaveDialog}
                title={t("ORGANIZATION_LEAVE_TITLE")} />

            }
        </Container>
    )
}
OrganizationMenu.propTypes = {
    id: PropTypes.string,
    name: PropTypes.string,
    isOrganizationOwner: PropTypes.bool,
    onDelete: PropTypes.any,
    userInOrganizationId: PropTypes.string.isRequired,
    isCourseAdministrator: PropTypes.bool,
    isCourseEditor: PropTypes.bool,
    isLector: PropTypes.bool,
    isOrganizationAdministrator: PropTypes.bool,
    isStudent: PropTypes.bool
};