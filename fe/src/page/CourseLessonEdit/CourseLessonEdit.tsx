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
import CustomDragAndDropPanel from '../../component/CustomDragAndDropPanel/CustomDragAndDropPanel'
import { AddCourseLesson } from '../../WebModel/CourseLesson/AddCourseLesson'
import { UpdateCourseLesson } from '../../WebModel/CourseLesson/UpdateCourseLesson'

export default function CourseLessonEdit () {
  const { t } = useTranslation()
  var id = GetUrlParam('id')
  const classes = useStyles()
  const [valueTab, setValueTab] = React.useState(0)
  const [courseLessonName, setCourseLessonName] = React.useState('')
  const [courseLessonDescription, setCourseLessonDescription] = React.useState('')
  const [courseLessonItems,setCourseLessonItems] =React.useState([]);

  const goToTab = GetUrlParam('gototab')

  const handleChangeCourseLessonName = (event: any) => {
    setCourseLessonName(event.target.value)
  }

  const handleChangeCourseLessonDescription = (event: any) => {
    setCourseLessonDescription(event.target.value)
  }

  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue)
  }
  const loadCourseLessonItem =()=>
  {
    axiosInstance.get("webportal/CourseLessonItem/GetCourseLessonItems",{
      params:{
        accessToken: GetUserToken(),
        courseLessonId: id
      }
    }).then(function(response:any){
      setCourseLessonItems(response.data.data.map(function (item: any) {
        return {
          id: item.id,
          primary: item.name,
          secondary: item.description
        }
      }));
    });
  }
  const moveItem = (result: any) => {
    const ids = result.map(function (item: any) {
      return item.id
    })
  }

  useEffect(() => {
    const fetchData = async () => {
      if (goToTab === 'courselessonitems') {
        setValueTab(1)
      } else {
        setValueTab(0)
      }
      if (id === '') {  
        setValueTab(0)
      } else {
        await axiosInstance.get('webportal/CourseLesson/GetCourseLessonDetail', {
          params: {
            accessToken: GetUserToken(),
            courseLessonId: id
          }
        }).then(function (response: any) {
          setCourseLessonName(response.data.data.name)
          setCourseLessonDescription(response.data.data.description)
        });
        loadCourseLessonItem();

      }
    }
    fetchData()
  }, [])

  const saveBasicData = () => {
    if (id === '') {
      const obj = new AddCourseLesson(courseLessonName, courseLessonDescription, GetUrlParam('courseId'), GetUserToken())
      axiosInstance.post('webportal/CourseLesson/AddCourseLesson', obj)
    } else {
      const obj = new UpdateCourseLesson(id, courseLessonName, courseLessonDescription, GetUserToken())
      axiosInstance.put('webportal/CourseLesson/UpdateCourseLesson', obj)
    }
  }

  return (
    <Container component='main' maxWidth='xl'>
      <PageName title={t('COURSE_LESSON_TITLE') + ' - ' + courseLessonName} />
      <Paper>
        <AppBar position='static'>
          <Tabs value={valueTab} onChange={handleChangeTab} >
            <Tab label={t('COURSE_LESSON_TAB_BASIC_INFORMATION')} {...a11yProps(0)} />
            <Tab label={t('COURSE_LESSON_TAB_LESSON_ITEMS')} {...a11yProps(1)} disabled={id === null} />

          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form}
            onSubmit={saveBasicData}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextValidator
                  label={t('COURSE_LESSON_NAME')}
                  onChange={handleChangeCourseLessonName}
                  name='courseLessonName'
                  value={courseLessonName}
                  validators={['required']}
                  errorMessages={[t('VALIDATION_REQUIRED')]}
                  variant='outlined'
                  fullWidth
                  id='courseLessonName'
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t('COURSE_ĹESSON_DESCRIPTION')}
                  onChange={handleChangeCourseLessonDescription}
                  name='courseLessonDescription'
                  value={courseLessonDescription}
                  variant='outlined'
                  fullWidth
                  id='courseLessonDescription'
                  rows={5}
                  multiline={true}
                />
              </Grid>
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={'/organization/course/?id=' + GetUrlParam('organizationId') + '&gototab=course'} />

          </ValidatorForm>
        </TabPanel>

        <TabPanel value={valueTab} index={1}>
          <CustomDragAndDropPanel Data={courseLessonItems} ShowAddButton={true} AddLinkText={t('COURSE_ADD_LESSON_ITEM')} 
          AddLinkUri={'/courselessonitem/add?courseLessonId=' + id} onMove={moveItem}
          ShowEdit={true} EditLinkUri={'/courselessonitem/edit'}
          />

        </TabPanel>

      </Paper>

    </Container>
  )
}
CourseLessonEdit.prototype = {
  cbCountry: PropTypes.any,
  cbAddressType: PropTypes.any
}
