import React  from 'react';
import useStyles from '../../styles';
import { axiosInstance } from '../../axiosInstance';
import QuestionDialog from '../QuestionDialog/QuestionDialog';
import { Container,  Button, Box } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import PropTypes from 'prop-types';
export default function ButtonDelete(props: any) {
    const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false);
    const { DeleteUrl, DeleteDialogTitle, DeleteButtonText, DeleteDialogContent, onDelete, fullWidth } = props;
  
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
          fullWidth={fullWidth}
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
    onDelete: PropTypes.any,
    fullWidth:PropTypes.bool
  
  };