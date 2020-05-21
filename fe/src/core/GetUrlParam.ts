export default function GetUrlParam(paramName:string){
    if (paramName ==="")
    {
        return "";
    }
    var url = new URL(window.location.href);
    let  value =url.searchParams.get(paramName);
    if (value === null)
    {
        return "";
    }
    return value;
}