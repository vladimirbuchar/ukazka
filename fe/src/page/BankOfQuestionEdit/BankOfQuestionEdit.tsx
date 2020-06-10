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
import { AddBankOfQuestion } from '../../WebModel/BankOfQuestion/AddBankOfQuestion'
import { UpdateBankOfQuestion } from '../../WebModel/BankOfQuestion/UpdateBankOfQuestion'

export default function BankOfQuestionEdit () {
  const { t } = useTranslation()
  var id = GetUrlParam('id')
  const classes = useStyles()
  const [valueTab, setValueTab] = React.useState(0)
  const [bankOfQuestionName, setBankOfQuestionName] = React.useState('')
  const [bankOfQuestionLessonDescription, setBankOfQuestionDescription] = React.useState('')
  const [questions,setQuestions] =React.useState([]);

  const goToTab = GetUrlParam('gototab')

  const handleChangeBankOfQuestionName = (event: any) => {
    setBankOfQuestionName(event.target.value)
  }

  const handleChangeBankOfQuestionDescription = (event: any) => {
    setBankOfQuestionDescription(event.target.value)
  }

  const handleChangeTab = (event: any, newValue: any) => {
    setValueTab(newValue)
  }
  const loadQuestions =()=>
  {
    axiosInstance.get("webportal/Question/GetQuestionsInBank",{
      params:{
        accessToken: GetUserToken(),
        bankOfQuestionId: id
      }
    }).then(function(response:any){
      setQuestions(response.data.data.map(function (item: any) {
        return {
          id: item.id,
          primary: item.name,
          secondary: item.description
        }
      }));
    });
  }
  

  useEffect(() => {
    const fetchData = async () => {
      if (goToTab === 'questions') {
        setValueTab(1)
      } else {
        setValueTab(0)
      }
      if (id === '') {  
        setValueTab(0)
      } else {
        await axiosInstance.get('webportal/BankOfQuestion/GetBankOfQuestionDetail', {
          params: {
            accessToken: GetUserToken(),
            bankOfQuestionId: id
          }
        }).then(function (response: any) {
          setBankOfQuestionName(response.data.data.name)
          setBankOfQuestionDescription(response.data.data.description)
        });
        loadQuestions();

      }
    }
    fetchData()
  }, [])

  const saveBasicData = () => {
    if (id === '') {
      const obj = new AddBankOfQuestion(bankOfQuestionName, bankOfQuestionLessonDescription, GetUrlParam('organizationId'), GetUserToken())
      axiosInstance.post('webportal/BankOfQuestion/AddBankOfQuestion', obj)
    } else {
      const obj = new UpdateBankOfQuestion(id, bankOfQuestionName, bankOfQuestionLessonDescription, GetUserToken())
      axiosInstance.put('webportal/BankOfQuestion/UpdateBankOfQuestion', obj)
    }
  }

  return (
    <Container component='main' maxWidth='xl'>
      <PageName title={t('BANK_OF_QUESTION_TITLE') + ' - ' + bankOfQuestionName} />
      <Paper>
        <AppBar position='static'>
          <Tabs value={valueTab} onChange={handleChangeTab} >
            <Tab label={t('BANK_OF_QUESTION_TAB_BASIC_INFORMATION')} {...a11yProps(0)} />
            <Tab label={t('BANK_OF_QUESTION_TAB_QUESTIONS')} {...a11yProps(1)} disabled={id === null} />

          </Tabs>
        </AppBar>
        <TabPanel value={valueTab} index={0}>
          <ValidatorForm className={classes.form}
            onSubmit={saveBasicData}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextValidator
                  label={t('BANK_OF_QUESTION_NAME')}
                  onChange={handleChangeBankOfQuestionName}
                  name='bankOfQuestionName'
                  value={bankOfQuestionName}
                  validators={['required']}
                  errorMessages={[t('VALIDATION_REQUIRED')]}
                  variant='outlined'
                  fullWidth
                  id='bankOfQuestionName'
                />
              </Grid>
              <Grid item xs={12}>
                <TextValidator
                  label={t('BANK_OF_QUESTION_DESCRIPTION')}
                  onChange={handleChangeBankOfQuestionDescription}
                  name='bankOfQuestionLessonDescription'
                  value={bankOfQuestionLessonDescription}
                  variant='outlined'
                  fullWidth
                  id='bankOfQuestionLessonDescription'
                  rows={5}
                  multiline={true}
                />
              </Grid>
            </Grid>
            <SaveButtons onSave={saveBasicData} backUrl={'/organization/course/?id=' + GetUrlParam('organizationId') + '&gototab=course'} />

          </ValidatorForm>
        </TabPanel>

        <TabPanel value={valueTab} index={1}>
          

        </TabPanel>

      </Paper>

    </Container>
  )
}
BankOfQuestionEdit.prototype = {
  cbCountry: PropTypes.any,
  cbAddressType: PropTypes.any
}
