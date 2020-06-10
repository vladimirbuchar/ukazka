export class AddCourseLesson{
    public Name: string;
    public Description: string;
    public CourseId:string;
    public UserAccessToken: string;
    constructor(name:string,description:string,courseId: string, userAccessToken:string)
    {
        this.CourseId = courseId;
        this.Description = description;
        this.Name = name;
        this.UserAccessToken = userAccessToken
    }
}