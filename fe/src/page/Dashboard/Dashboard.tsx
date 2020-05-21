import React from 'react';
import Typography from '@material-ui/core/Typography';
import { useTranslation } from 'react-i18next';
import useStyles from './../../styles';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import { Container, ExpansionPanel, ExpansionPanelSummary, ExpansionPanelDetails } from '@material-ui/core';
import Organization from '../../component/Organization/Organization';
import PageName from '../../component/PageName/PageName';

export default function Dashboard() {
  const { t } = useTranslation();
  const classes = useStyles();

  
 return (
  <Container component="main" maxWidth="xl">
    <PageName title={t("DASHBOARD_TITLE")} />
<ExpansionPanel>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography className={classes.heading}>{t("DASHBOARD_ORGANIZATION_TITLE")}</Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
        <Organization />
        </ExpansionPanelDetails>
      </ExpansionPanel>
      <ExpansionPanel>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel2a-content"
          id="panel2a-header"
        >
          <Typography className={classes.heading}>{t("DASHBOARD_COURSE_TITLE")}</Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <Typography>
            Zde budou kurzuy
          </Typography>
        </ExpansionPanelDetails>
      </ExpansionPanel>
      


      
</Container>
  );
}