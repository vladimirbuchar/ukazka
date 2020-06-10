import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import signinen from './page/SignIn/SignIn.i18.en.json';
import signincs from './page/SignIn/SignIn.i18.cs.json';
import menucs from './component/Menu/Menu.i18n.cs.json';
import menuen from './component/Menu/Menu.i18n.en.json';
import signupen from './page/SignUp/SignUp.i18n.en.json';
import signupcs from './page/SignUp/SignUp.i18n.cs.json';
import validationcs from './i118n/Validation.i18n.cs.json';
import validationen from './i118n/Validation.i18n.en.json';
import myprofilecs from './page/MyProfile/MyProfile.i18n.cs.json';
import myprofileen from './page/MyProfile/MyProfile.i18n.en.json';
import organizationcs from './component/Organization/Organization.i18n.cs.json';
import dashboardcs from './page/Dashboard/Dashboard.i18n.cs.json';
import organizationeditcs from './page/OrganizationEdit/OrganizationEdit.i18n.cs.json';
import branchcs from './page/BranchEdit/BranchEdit.i18n.cs.json';
import classroomcs from './page/ClassRoomEdit/ClassRoomEdit.i18n.cs.json';
import questiondialogcs from './component/QuestionDialog/QuestionDialog.i18n.cs.json';
import myorgsanizationscs from './page/OrganizationList/OrganizationList.i18n.cs.json';
import addUserToOrgnizationCs  from './page/AddUserToOrganization/AddUserToOrganization.i18n.cs.json';
import organizationRoleCs from './i118n/OrganizationRole.i18n.cs.json';
import notificationlistcs from './page/NotificationList/NotificationList.i18n.cs.json';
import courseeditcs from './page/CourseEdit/CourseEdit.i18n.cs.json';
import addresscs from  './component/AddressField/AddressField.i18n.cs.json';
import contactcs from './component/ContactField/ContactField.i18n.cs.json';
import accessforbidencs from './component/AccessForbiden/AccessForbiden.i18n.cs.json';
import savebuttonscs from './component/SaveButtons/SaveButtons.i18n.cs.json';
import codebookcs from './component/CodeBook/CodeBook.i18n.cs.json';
import coursetermeditcs  from './page/CourseTermEdit/CourseTermEdit.i18n.cs.json';
import coursepricecs from './component/CoursePrice/CoursePrice.i18n.cs.json';
import coursestudentcountcs from './component/CourseStudentCount/CourseStudentCount.i18.cs.json';
import addstudenttotermcs from './page/AddStudentToTerm/AddStudentToTerm.i18n.cs.json' ;
import courseleesoneditcs from './page/CourseLessonEdit/CourseLessonEdit.i18n.cs.json';
import courselessitemeditcs from './page/CourseLessonItemEdit/CourseLessonItemEdit.i18n.cs.json';
import fileuploadcs from './component/FileUpload/FileUpload.i18n.cs.json';
import bankofquestioncs from './page/BankOfQuestionEdit/BankOfQuestionEdit.i18n.cs.json';
i18n.use(LanguageDetector).init({
  // we init with resources
  resources: {
    en: {
      translations: Object.assign({}, signinen, menuen,signupen,validationen,myprofileen)
      
    }, 
    cs:{
        translations:Object.assign({},signincs,menucs,signupcs,validationcs,myprofilecs,organizationcs,dashboardcs,organizationeditcs,branchcs,classroomcs,questiondialogcs,myorgsanizationscs,addUserToOrgnizationCs,organizationRoleCs,notificationlistcs,courseeditcs,addresscs,contactcs,accessforbidencs,savebuttonscs,codebookcs,coursetermeditcs,coursepricecs,coursestudentcountcs,addstudenttotermcs,courseleesoneditcs,courselessitemeditcs,fileuploadcs,bankofquestioncs)
    } 
  },
  fallbackLng: "en",
  debug: false,

  // have a common namespace used around the full app
  ns: ["translations"],
  defaultNS: "translations",

  keySeparator: false, // we use content as keys

  interpolation: {
    escapeValue: false, // not needed for react!!
    formatSeparator: ","
  },

  react: {
    wait: true
  }
});

export default i18n;
export const getLanguage = () => {
    return i18n.language ||
      (typeof window !== 'undefined' && window.localStorage.i18nextLng) ||
      'en';
  };
  export const changeLanguage=(language:string)=>{
    i18n.changeLanguage(language);
  };