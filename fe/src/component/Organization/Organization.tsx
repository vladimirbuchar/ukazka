import React, { useEffect } from 'react';
import {   ButtonGroup, Grid, Paper, ButtonBase, List } from '@material-ui/core';
import { axiosInstance } from '../../axiosInstance';
import { useTranslation } from 'react-i18next';
import { Container} from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { Link as ReactLink } from "react-router-dom";
import useStyles from '../../styles';
import BusinessIcon from '@material-ui/icons/Business';
import GetUserToken from '../../core/GetUserToken';
import { OrganizationMenu } from './OrganizationMenu';
import { OrganizationName } from './OrganizationName';

export default function Organization() {

    const [organizations, setOrganizations] = React.useState([]);
    const [dataEmpty, setDataEmpty] = React.useState("");
    const classes = useStyles();
    const deleteFunction =()=>
    {
        reloadMyOrganization();
    }
    const reloadMyOrganization = async ()=>
    {
         axiosInstance.get("webportal/Organization/GetMyOrganizations/",{
             params:{
                accessToken: GetUserToken()
             }
         }).then(function (response) {

            if (response?.data?.data.length === 0) {
                setDataEmpty(t("ORGANIZATION_EMPTY_DATA"));
                setOrganizations([]);
            }
            else {
                let organizationList = [] as any;
                let i = 0;
                response?.data?.data.forEach(function (item: any) {
                    const row =
                        <Grid item lg={4} key={item.id}>
                            <Paper className={classes.paper}>
                                <Grid container spacing={0}>
                                    <Grid item>
                                        <ButtonBase className={classes.image}>
                                            <BusinessIcon className={classes.img} width="100%" />
                                        </ButtonBase>
                                    </Grid>
                                    <Grid item xs={12} sm container>
                                        <Grid item xs container direction="column" spacing={2} className={classes.organizationName}>
                                            <OrganizationName name={item.name} description={item.description}  isOrganizationOwner={item.isOrganizationOwner} />
                                        </Grid>
                                        <Grid item>
                                            <List component="nav" aria-label="main mailbox folders">
                                                <OrganizationMenu id={item.id} isOrganizationOwner={item.isOrganizationOwner} name={item.name} 
                                                onDelete={deleteFunction} userInOrganizationId={item.userInOrganizationRoleId} 
                                                isCourseAdministrator={item.isCourseAdministrator} isCourseEditor={item.isCourseEditor}
                                                isLector={item.isLector} isOrganizationAdministrator={item.isOrganizationAdministrator}
                                                isStudent={item.isStudent}
                                                />
                                            </List>

                                        </Grid>
                                    </Grid>
                                </Grid>
                            </Paper>



                        </Grid>
                    organizationList[i] = row;
                    i++;
                });

                setOrganizations(organizationList);

            }


        });
    }
    

    const { t } = useTranslation();

    useEffect(() => {
        const fetchData = async () => {
            reloadMyOrganization();
        }
        fetchData();
    }, []);

    
    return (
        <Container component="main" maxWidth="xl">
            <ButtonGroup  color="primary" aria-label="outlined primary button group">
                <Button component={ReactLink} to="/organization/add">{t("ORGANIZATION_BUTTON_ADD")}</Button>
                <Button color="primary">{t("ORGANIZATION_BUTTON_FIND")}</Button>
            </ButtonGroup>
            <Grid container spacing={2}>
                <Grid item xs={12} >
                    {dataEmpty}
                </Grid>
                
                {organizations}

            </Grid>
        </Container>

    )
}

