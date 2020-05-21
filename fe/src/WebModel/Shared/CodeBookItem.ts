export class CodeBookItem {
    public id: string;
    public name: string;
    public isDefault: boolean;
    public systemIdentificator: string;

    constructor(id: string, name: string, isDefault: boolean, systemIdentificator: string) {
        this.id = id;
        this.name = name;
        this.isDefault = isDefault;
        this.systemIdentificator = systemIdentificator;
    }
}