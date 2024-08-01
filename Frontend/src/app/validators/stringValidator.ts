export class StringValidator{
    static isNumeric = function (value: string) {
        return /^\d+(?:\.\d+)?$/.test(value);
      };
}