import { Price } from "../Shared/Price";

export class AddCourseTerm {
    public CourseId: string;
    public Price: Price;
    public ActiveFrom: Date;
    public ActiveTo: Date;
    public RegistrationFrom: Date;
    public RegistrationTo: Date;
    public MinimumStudents: number;
    public MaximumStudents: number;
    public ClassRoomId: string;
    public Monday: boolean;
    public Tuesday: boolean;
    public Wednesday: boolean;
    public Thursday: boolean;
    public Friday: boolean;
    public Saturday: boolean;
    public Sunday: boolean;
    public TimeFromId: string;
    public TimeToId: string;
    public UserAccessToken: string;
    public Name: string;
    public Description: string;
    public Lector: [] ;
    constructor(courseId:string, price:Price,activeFrom: Date,activeTo:Date,registrationFrom:Date,registrationTo:Date, minimumStudents:number, maximumStudents:number, classRoomId: string, monday:boolean, tuesday:boolean,wednesday:boolean, thursday:boolean, friday:boolean, saturday:boolean, sunday:boolean, timeFromId: string, timeToId:string, userAccessToken: string, name:string, description:string, lector:[])
    {
        this.CourseId = courseId;
        this.Price = price;
        this.ActiveFrom = activeFrom;
        this.ActiveTo = activeTo;
        this.RegistrationFrom = registrationFrom;
        this.RegistrationTo = registrationTo;
        this.MaximumStudents = Number(maximumStudents);
        this.MinimumStudents = Number(minimumStudents);
        this.ClassRoomId = classRoomId;
        this.Monday = monday;
        this.Tuesday = thursday;
        this.Wednesday = wednesday;
        this.Thursday = thursday;
        this.Friday = friday;
        this.Saturday = saturday;
        this.Sunday = sunday;
        this.TimeFromId = timeFromId;
        this.TimeToId = timeToId;
        this.UserAccessToken = userAccessToken;
        this.Name = name;
        this.Description = description;
        this.Lector =lector;
    }
}