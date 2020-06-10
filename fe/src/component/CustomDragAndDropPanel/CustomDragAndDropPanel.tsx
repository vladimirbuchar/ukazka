import React from 'react'
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd'
import RootRef from '@material-ui/core/RootRef'
import { Link as ReactLink } from 'react-router-dom'
import {
  List,
  ListItem,
  ListItemText,
  ListItemIcon,
  IconButton,
  Container,
  Box,
  ButtonGroup,
  Button,
  ListItemSecondaryAction
} from '@material-ui/core'
import InboxIcon from '@material-ui/icons/Inbox'
import PropTypes from 'prop-types'
import GetUserToken from '../../core/GetUserToken'
import QuestionDialog from '../QuestionDialog/QuestionDialog'
import { axiosInstance } from '../../axiosInstance'
import ButtonDelete from '../ButtonDelete/ButtonDelete'
import { ButtonEdit } from '../ButtonEdit/ButtonEdit'

export default function CustomDragAndDropPanel (props: any) {
  const [openDeleteDialog, setOpenDeleteDialog] = React.useState(false)
  const [selectId, setSelectId] = React.useState('')
  const { EditLinkText,DeleteButtonText, ReplaceContent, ShowAddButton, AddLinkUri, AddLinkText, onMove, ShowEdit, EditLinkUri, ShowDelete, DeleteUrl, DeleteDialogTitle, DeleteDialogContent, onReload, DeleteParamIdName } = props
  let { Data } = props
  const onDragEnd = (result: any) => {
    // dropped outside the list
    if (!result.destination) {
      return
    }
    const items = reorder(
      Data,
      result.source.index,
      result.destination.index
    )
    onMove(items)
    Data = items
  }
  const handleCloseDeleteDialog = () => {
    setOpenDeleteDialog(false)
    setSelectId('')
  }
  
  const handleDelete = () => {
    axiosInstance.delete(DeleteUrl + '?' + DeleteParamIdName + '=' + selectId + '&accessToken=' + GetUserToken()).then(function () {
      setOpenDeleteDialog(false)
      onReload()
      setSelectId('')
    })
  }
  return (
    <Container component="main" maxWidth="xl">
      <Box paddingBottom={2}>
        <ButtonGroup color="primary" aria-label="outlined primary button group" >
          {ShowAddButton &&
            <Button component={ReactLink} to={AddLinkUri}>{AddLinkText}</Button>
          }
        </ButtonGroup>
      </Box>

      <DragDropContext onDragEnd={onDragEnd}>
        <Droppable droppableId="droppable">
          {(provided: any, snapshot: any) => (
            <RootRef rootRef={provided.innerRef}>
              <List style={getListStyle(snapshot.isDraggingOver)}>
                {Data.map((item: any, index: any) => (
                  <Draggable key={item.id} draggableId={item.id} index={index}>
                    {(provided, snapshot) => (
                      <ListItem data-itemid={item.id}
                        component="li"
                        ref={provided.innerRef}
                        {...provided.draggableProps}
                        {...provided.dragHandleProps}
                        style={getItemStyle(
                          snapshot.isDragging,
                          provided.draggableProps.style
                        )}
                      >
                        <ListItemIcon>
                          <InboxIcon />
                        </ListItemIcon>
                        <ListItemText
                          primary={item.primary}
                          secondary={item.secondary}
                        />
                        
                          <ListItemIcon>
                            
                          {ShowEdit &&
                            <ButtonEdit Text={EditLinkText} Uri={EditLinkUri + '?id=' + item.id} fullWidth={true}/>
                          }
                          <br />
                          {ShowDelete &&
                          <ButtonDelete DeleteUrl={DeleteUrl + '?' + DeleteParamIdName + '=' + item.id + '&accessToken=' + GetUserToken()} fullWidth={true}
                          DeleteDialogTitle={DeleteDialogTitle} DeleteButtonText={DeleteButtonText} DeleteDialogContent={DeleteDialogContent.replace('{' + ReplaceContent + '}', item[ReplaceContent])} onDelete={onReload} />
                          }
                          
                          </ListItemIcon>
                        
                        

                        
                        {openDeleteDialog && <QuestionDialog title={DeleteDialogTitle} openDialog={openDeleteDialog} onCloseDialog={handleCloseDeleteDialog}
                          content={DeleteDialogContent} oclickYes={handleDelete}
                        />}
                      </ListItem>
                    )}
                  </Draggable>
                ))}
                {provided.placeholder}
              </List>
            </RootRef>
          )}
        </Droppable>
      </DragDropContext>
    </Container>

  )
}
CustomDragAndDropPanel.prototype = {
  Data: PropTypes.array,
  ShowAddButton: PropTypes.bool,
  AddLinkUri: PropTypes.string,
  AddLinkText: PropTypes.string,
  onMove: PropTypes.func,
  ShowEdit: PropTypes.bool,
  EditLinkUri: PropTypes.string,
  EditLinkText: PropTypes.string,
  ShowDelete: PropTypes.bool,
  DeleteUrl: PropTypes.string,
  DeleteDialogTitle: PropTypes.string,
  DeleteButtonText: PropTypes.string,
  DeleteDialogContent: PropTypes.string,
  DeleteParamIdName: PropTypes.string,
  onReload: PropTypes.func,
  ReplaceContent: PropTypes.string

}

// a little function to help us with reordering the result
const reorder = (list: any, startIndex: any, endIndex: any) => {
  const result = Array.from(list)
  const [removed] = result.splice(startIndex, 1)
  result.splice(endIndex, 0, removed)
  return result
}

const getItemStyle = (isDragging: any, draggableStyle: any) => ({
  // styles we need to apply on draggables
  ...draggableStyle,

  ...(isDragging && {
    background: 'rgb(235,235,235)'
  })
})

const getListStyle = (isDraggingOver: any) => ({
  // background: isDraggingOver ? 'lightblue' : 'lightgrey',
})
