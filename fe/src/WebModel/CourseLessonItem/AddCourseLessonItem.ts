export class AddCourseLessonItem{
    public Name: string;
    public Description: string;
    public CourseLessonId:string;
    public UserAccessToken: string;
    public TemplateId: string;
    public Html: string;
    constructor(name:string,description:string,courseLessonId: string, userAccessToken:string, templateId: string, html:string)
    {
        this.CourseLessonId = courseLessonId;
        this.Description = description;
        this.Name = name;
        this.UserAccessToken = userAccessToken
        this.TemplateId = templateId
        this.Html = html
    }
}