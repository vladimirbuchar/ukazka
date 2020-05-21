export default function GetUserToken() {
    let token = window.sessionStorage.getItem("userToken");
    
    if (token === null || token === undefined || token==="undefined")
    {
        return "";
    }
    return token;
  }