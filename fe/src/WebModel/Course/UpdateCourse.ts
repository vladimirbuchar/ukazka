import { Price } from "../Shared/Price";

export  class UpdateCourse {
    constructor(id: string,isPrivateCourse: boolean, userAccessToken: string, name: string, description: string,  defaultMaximumStudents: number,
        defaultMinimumStudents: number, courseImage: string, price:Price,courseStatusId: string, courseTypeId: string) {
        this.isPrivateCourse = isPrivateCourse;
        this.userAccessToken = userAccessToken;
        this.name = name;
        this.description = description;
        this.defaultMaximumStudents = defaultMaximumStudents;
        this.defaultMinimumStudents = defaultMinimumStudents;
        this.courseImage = courseImage;
        this.price = price;
        this.courseStatusId = courseStatusId;
        this.courseTypeId = courseTypeId;
        this.Id = id;
    }
    public Id: string;
    public isPrivateCourse: boolean;
    public userAccessToken: string;
    public name: string;
    public description: string;
    public defaultMaximumStudents: number;
    public defaultMinimumStudents: number;
    public courseImage: string;
    public price: Price;
    public courseStatusId: string;
    public courseTypeId: string;
}