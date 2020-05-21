export class InsertUserToOrganization{
    public UserEmails: string[];
    public OrganizationId: string;
    public OrganizationRoleId: string;
    public UserAccessToken: string;
    constructor (userEmails: string[],organizationId:string, organizationRoleId:string,userAccessToken:string)
    {
        this.OrganizationId = organizationId;
        this.OrganizationRoleId = organizationRoleId;
        this.UserAccessToken = userAccessToken;
        this.UserEmails = userEmails;
    }
}