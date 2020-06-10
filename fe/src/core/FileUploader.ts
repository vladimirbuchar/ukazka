import { axiosInstance } from "../axiosInstance";
import GetUserToken from "./GetUserToken";

export default function FileUploader(files: Array<any>,objectOwner: string){
    var formData = new FormData();
          formData.append("file", files[0])
          axiosInstance.post('webportal/FileUpload/FileUpload', formData, {
            params: {
              accessToken: GetUserToken(),
              objectOwner: objectOwner
            },
            headers: {
              'Content-Type': 'multipart/form-data'
            }
          })

}