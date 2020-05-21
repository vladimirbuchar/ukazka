export default function GetUserId() {
    let userId = window.sessionStorage.getItem("userId");
    if (userId === null )
    {
        return "";
    }
    return userId;
  }