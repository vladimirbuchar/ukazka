import React, { forwardRef } from 'react';
import { Container, ButtonGroup, Button, Box } from '@material-ui/core';
import { Link as ReactLink } from "react-router-dom";
import MaterialTable from 'material-table';
import PropTypes from 'prop-types';
import AddBox from '@material-ui/icons/AddBox';
import EditIcon from '@material-ui/icons/Edit';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';
import DeleteIcon from '@material-ui/icons/Delete';
import useStyles from '../../styles';
import QuestionDialog from '../QuestionDialog/QuestionDialog';
import { axiosInstance } from '../../axiosInstance';
import GetUserToken from '../../core/GetUserToken';


export default function CustomTable(props: any) {
  const { ShowAddButton,AddLinkUri, DeleteParamIdName, AddLinkText, Columns, Data, ShowDelete, ShowEdit, EditLinkText, EditLinkUri, DeleteUrl, DeleteDialogTitle, DeleteButtonText, DeleteDialogContent, onReload, ReplaceContent, EditParams } = props;
  if (ShowEdit) {
    Columns[Columns.length] = { title: '', field: 'edit' }
  }
  if (ShowDelete) {
    Columns[Columns.length] = { title: '', field: 'delete' }
  }
  Data.forEach(function (item: any) {
    if (!item.hideActionButton) {
      if (ShowEdit) {
        if (EditParams === undefined || EditParams === "" )
        {
          item.edit = <ButtonEdit Text={EditLinkText} Uri={EditLinkUri + "?id=" + item.id} />;
        }
        else 
        {
          item.edit = <ButtonEdit Text={EditLinkText} Uri={EditLinkUri + "?id=" + item.id+"&"+EditParams} />;
        }
      }
      if (ShowDelete) {
        item.delete = <ButtonDelete DeleteUrl={DeleteUrl + "?" + DeleteParamIdName + "=" + item.id + "&accessToken=" + GetUserToken()}
          DeleteDialogTitle={DeleteDialogTitle} DeleteButtonText={DeleteButtonText} DeleteDialogContent={DeleteDialogContent.replace("{" + ReplaceContent + "}", item[ReplaceContent])} onDelete={onReload} />;
      }
    }
  });
  const tableIcons = {
    Add: forwardRef((props: any, ref: any) => <AddBox {...props} ref={ref} />),
    Check: forwardRef((props: any, ref: any) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props: any, ref: any) => <Clear {...props} ref={ref} />),
    Delete: forwardRef((props: any, ref: any) => <DeleteOutline {...props} ref={ref} />),
    DetailPanel: forwardRef((props: any, ref: any) => <ChevronRight {...props} ref={ref} />),
    Edit: forwardRef((props: any, ref: any) => <Edit {...props} ref={ref} />),
    Export: forwardRef((props: any, ref: any) => <SaveAlt {...props} ref={ref} />),
    Filter: forwardRef((props: any, ref: any) => <FilterList {...props} ref={ref} />),
    FirstPage: forwardRef((props: any, ref: any) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props: any, ref: any) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props: any, ref: any) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props: any, ref: any) => <ChevronLeft {...props} ref={ref} />),
    ResetSearch: forwardRef((props: any, ref: any) => <Clear {...props} ref={ref} />),
    Search: forwardRef((props: any, ref: any) => <Search {...props} ref={ref} />),
    SortArrow: forwardRef((props: any, ref: any) => <ArrowDownward {...props} ref={ref} />),
    ThirdStateCheck: forwardRef((props: any, ref: any) => <Remove {...props} ref={ref} />),
    ViewColumn: forwardRef((props: any, ref: any) => <ViewColumn {...props} ref={ref} />)
  };
  return (
    <Container component="main" maxWidth="xl">
      <Box paddingBottom={2}>
        <ButtonGroup color="primary" aria-label="outlined primary button group" >
        {ShowAddButton &&
          <Button component={ReactLink} to={AddLinkUri}>{AddLinkText}</Button>
        }
        </ButtonGroup>
      </Box>
      <MaterialTable
        
        title=""
        columns={Columns}
        data={Data}
      />

    </Container>
  );
}
CustomTable.prototype = {
  AddLinkUri: PropTypes.string,
  AddLinkText: PropTypes.string,
  Columns: PropTypes.array,
  Data: PropTypes.any,
  ShowDelete: PropTypes.bool,
  ShowEdit: PropTypes.bool,
  EditLinkUri: PropTypes.string,
  EditLinkText: PropTypes.string,
  DeleteUrl: PropTypes.string,
  DeleteDialogTitle: PropTypes.string,
  DeleteButtonText: PropTypes.string,
  DeleteDialogContent: PropTypes.string,
  DeleteParamIdName: PropTypes.string,
  onReload: PropTypes.any,
  ReplaceContent: PropTypes.string,
  ShowAddButton: PropTypes.bool,
  EditParams: PropTypes.string
}


function ButtonEdit(props: any) {
  const classes = useStyles();
  const { Text, Uri } = props;
  return (<Button

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
  Uri: PropTypes.string
}

function ButtonDelete(props: any) {
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
  const { DeleteUrl, DeleteDialogTitle, DeleteButtonText, DeleteDialogContent, onDelete } = props;

  const classes = useStyles();
  const handleCloseDeleteDialog = () => {
    setOpenDeleteDialog(false);
  };
  const handleClickOpenDeleteDialog = () => {
    setOpenDeleteDialog(true);
  };
  const handleDelete = () => {
    axiosInstance.delete(DeleteUrl).then(function () {
      onDelete();
      setOpenDeleteDialog(false);
    });
  }

  return (

    <Container component="main" maxWidth="xl">
      {openDeleteDialog && <QuestionDialog title={DeleteDialogTitle} openDialog={openDeleteDialog} onCloseDialog={handleCloseDeleteDialog}
        content={DeleteDialogContent} oclickYes={handleDelete}
      />}
      <Button
        onClick={handleClickOpenDeleteDialog}
        variant="contained"
        color="primary"
        className={classes.button}
        startIcon={<DeleteIcon />}

      >
        {DeleteButtonText}
      </Button>
    </Container>
  )

}

ButtonDelete.propTypes = {
  DeleteUrl: PropTypes.string,
  DeleteDialogTitle: PropTypes.string,
  DeleteButtonText: PropTypes.string,
  DeleteDialogContent: PropTypes.string,
  onDelete: PropTypes.any

};