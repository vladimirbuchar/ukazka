import React from 'react'
import { Container, ButtonGroup, Button, Box } from '@material-ui/core'
import { Link as ReactLink } from 'react-router-dom'
import MaterialTable from 'material-table'
import PropTypes from 'prop-types'
import GetUserToken from '../../core/GetUserToken'
import { ButtonEdit } from '../ButtonEdit/ButtonEdit'
import ButtonDelete from '../ButtonDelete/ButtonDelete'

export default function CustomTable (props: any) {
  const { ShowAddButton, AddLinkUri, DeleteParamIdName, AddLinkText, Columns, Data, ShowDelete, ShowEdit, EditLinkText, EditLinkUri, DeleteUrl, DeleteDialogTitle, DeleteButtonText, DeleteDialogContent, onReload, ReplaceContent, EditParams } = props
  if (ShowEdit) {
    Columns[Columns.length] = { title: '', field: 'edit' }
  }
  if (ShowDelete) {
    Columns[Columns.length] = { title: '', field: 'delete' }
  }
  Data.forEach(function (item: any) {
    if (!item.hideActionButton) {
      if (ShowEdit) {
        if (EditParams === undefined || EditParams === '') item.edit = <ButtonEdit Text={EditLinkText} Uri={EditLinkUri + '?id=' + item.id} />
        else {
          item.edit = <ButtonEdit Text={EditLinkText} Uri={EditLinkUri + '?id=' + item.id + '&' + EditParams} />
        }
      }
      if (ShowDelete) {
        item.delete = <ButtonDelete DeleteUrl={DeleteUrl + '?' + DeleteParamIdName + '=' + item.id + '&accessToken=' + GetUserToken()}
          DeleteDialogTitle={DeleteDialogTitle} DeleteButtonText={DeleteButtonText} DeleteDialogContent={DeleteDialogContent.replace('{' + ReplaceContent + '}', item[ReplaceContent])} onDelete={onReload} />
      }
    }
  })

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
  )
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
