class InputManager {

    static MultiplyTen = false;
    static MultiplyHundred = false;

    static Init() {
        document.addEventListener('keydown', function ({ key }) {
            if (key === "Control") {
                InputManager.MultiplyTen = true;
            }
            else if (key === "Shift") {
                InputManager.MultiplyHundred = true;
            }
        });

        document.addEventListener('keyup', function ({ key }) {
            if (key === "Control") {
                InputManager.MultiplyTen = false;
            }
            if (key === "Shift") {
                InputManager.MultiplyHundred = false;
            }
        });
    }
}

InputManager.Init();