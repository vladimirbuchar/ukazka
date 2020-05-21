import { axiosInstance } from "../axiosInstance";
import OrganizationPermition from "../WebModel/Shared/OrganizationPermition";

export default async function GetUserOrganizationRole(userAccessToken: string, objectId: string, objectType: string) {
    let permitions: OrganizationPermition;
    if (objectType === "organization" && objectId === "") {
        permitions = new OrganizationPermition(true, true, true, true, true, true);
    }
    else {
        permitions = new OrganizationPermition(false, false, false, false, false, false);
        await axiosInstance.get("webportal/OrganizationUser/GetUserOrganizationRole", {
            params: {
                accessToken: userAccessToken,
                objectId: objectId,
                type: objectType
            }
        }).then(function (response) {
            permitions = response.data.data;
        });
    }
    return permitions;
}