export class LoginRequest {
    userName: string;
    passWord: string;

    /**
     *
     */
    constructor(userName: string, passWord: string) {
        this.userName = userName;
        this.passWord = passWord;
    }

}