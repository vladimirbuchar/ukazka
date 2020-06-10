import React, { useEffect } from 'react'
import Grid from '@material-ui/core/Grid'
import { useTranslation } from 'react-i18next'
import useStyles from './../../styles'
import { Container, AppBar, Tabs, Tab, Paper } from '@material-ui/core'
import { axiosInstance } from '../../axiosInstance'
import a11yProps from '../../component/A11yProps/A11yProps'
import TabPanel from '../../component/TabPanel/TabPanel'
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator'
import PageName from '../../component/PageName/PageName'
import GetUserToken from '../../core/GetUserToken'
import GetUrlParam from '../../core/GetUrlParam'
import PropTypes from 'prop-types'
import SaveButtons from '../../component/SaveButtons/SaveButtons'
import { AddCourseLessonItem } from '../../WebModel/CourseLessonItem/AddCourseLessonItem'
import { UpdateCourseLessonItem } from '../../WebModel/CourseLessonItem/UpdateCourseLessonItem'
import CodeBook from '../../component/CodeBook/CodeBook'
import { CodeBookItem } from './../../WebModel/Shared/CodeBookItem';
import _ from 'lodash';
import CustomHtmlEditor from '../../component/CustomHtmlEditor/CustomHtmlEditor'
import FileUpload from '../../component/FileUpload/FileUpload'
import FileUploader from '../../core/FileUploader'

export default function CourseLessonItemEdit(props: any) {
  const { cbCourseLessonItemType } = props;
  const { t } = useTranslation()
  var id = GetUrlParam('id')
  const classes = useStyles()
  const [valueTab, setValueTab] = React.useState(0)
  const [courseLessonItemName, setCourseLessonItemName] = React.useState('')
  const [courseLessonItemDescription, setCourseLessonItemDescription] = React.useState('')
  const [courseLessonItemTemplate, setCourseLessonItemTemplate] = React.useState('')
  const [templateIdentificator, setTemplateIdentificator] = React.useState('')
  const [htmlBasicTemplate, setHtmlBasicTemplate] = React.useState('');
  const [files, setFiles] = React.useState([]);
  const [fileName, setFileName] = React.useState('');
  const [fileId, setFileId] = React.useState('')

  const handleChangeHtmlBasicTemplate = (content: any) => {
    setHtmlBasicTemplate(content);
  }
  const onUpload = (files: any) => {
    setFiles(files);
  }

  const onChangeCourseLessonItemTemplate = (e: any) => {

    const item = cbCourseLessonItemType.find((x: CodeBookItem) => x.id === e.target.value);
    setTemplateIdentificator(_.get(item, 'systemIdentificator', ''));
    setCourseLessonItemTemplate(e.target.value)
  }


  const handleChangeCourseLessonItemName = (event: any) => {
    setCourseLessonItemName(event.target.value)
  }

  const handleChangeCourseLessonItemDescription = (event: any) => {
    setCourseLessonItemDescription(event.target.value)
  }

  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue)
  }

  useEffect(() => {
    const fetchData = async () => {


      if (id === '') {
        setValueTab(0)
      } else {
        await axiosInstance.get('webportal/CourseLessonItem/GetCourseLessonItemDetail', {
          params: {
            accessToken: GetUserToken(),
            courseLessonItemId: id
          }
        }).then(function (response: any) {
          setCourseLessonItemName(response.data.data.name)
          setCourseLessonItemDescription(response.data.data.description)
          setCourseLessonItemTemplate(response.data.data.courseLessonItemTemplateId)
          setHtmlBasicTemplate(response.data.data.html)
          setTemplateIdentificator(response.data.data.templateIdentificator)
          setFileName(response.data.data.originalFileName)
          setFileId(response.data.data.fileId);

        })
      }
    }
    fetchData()
  }, [])

  const saveBasicData = () => {
    if (id === '') {
      const obj = new AddCourseLessonItem(courseLessonItemName, courseLessonItemDescription, GetUrlParam('courseLessonId'), GetUserToken(), courseLessonItemTemplate, htmlBasicTemplate)
      axiosInstance.post('webportal/CourseLessonItem/AddCourseLessonItem', obj).then(function (response: any) {
        if (files.length > 0) {
          FileUploader(files,response.data.data);
        }

      })
    } else {
      const obj = new UpdateCourseLessonItem(id, courseLessonItemName, courseLessonItemDescription, GetUserToken(), courseLessonItemTemplate, htmlBasicTemplate)
      axiosInstance.put('webportal/CourseLessonItem/UpdateCourseLessonItem', obj).then(function(response:any){
        if (files.length > 0) {
          FileUploader(files,id);
        }
      })
    }
  }

  return (
    <Container component='main' maxWidth='xl'>
      <PageName title={t('COURSE_LESSON_ITEM_TITLE') + ' - ' + courseLessonItemName} />
      <Paper>
        <AppBar position='static'>
          <Tabs value={valueTab} onChange={handleChangeTab} >
            <Tab label={t('COURSE_LESSON_ITEM_TAB_BASIC_INFORMATION')} {...a11yProps(0)} />
          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form}
            onSubmit={saveBasicData}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextValidator
                  label={t('COURSE_LESSON_ITEM_NAME')}
                  onChange={handleChangeCourseLessonItemName}
                  name='courseLessonItemName'
                  value={courseLessonItemName}
                  validators={['required']}
                  errorMessages={[t('VALIDATION_REQUIRED')]}
                  variant='outlined'
                  fullWidth
                  id='courseLessonItemName'
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t('COURSE_LESSON_ITEM_DESCRIPTION')}
                  onChange={handleChangeCourseLessonItemDescription}
                  name='courseLessonItemDescription'
                  value={courseLessonItemDescription}
                  variant='outlined'
                  fullWidth
                  id='courseLessonItemDescription'
                  rows={5}
                  multiline={true}
                />
              </Grid>
              <Grid item xs={12}>
                <CodeBook codeBookIdentificator="cb_courselessonitemtemplate" label={t("COURSE_LESSON_ITEM_TEMPLATE")} id="courseLessonItemTemplate" value={courseLessonItemTemplate} onChange={onChangeCourseLessonItemTemplate} autoTranslate={true} data={cbCourseLessonItemType} />
              </Grid>
              <Grid item xs={12}>
                {templateIdentificator === 'BASIC_TEMPLATE' &&
                  <CustomHtmlEditor content={htmlBasicTemplate} onChangeContent={handleChangeHtmlBasicTemplate} />}

              </Grid>
              {templateIdentificator === 'BASIC_TEMPLATE_IMAGE' &&
                <FileUpload onUpload={onUpload} fileName={fileName} fileId={fileId}/>
              }
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={'/organization/course/?id=' + GetUrlParam('organizationId') + '&gototab=course'} />

          </ValidatorForm>
        </TabPanel>



      </Paper>

    </Container>
  )
}
CourseLessonItemEdit.prototype = {
  cbCountry: PropTypes.any,
  cbAddressType: PropTypes.any,
  cbCourseLessonItemType: PropTypes.any
}
