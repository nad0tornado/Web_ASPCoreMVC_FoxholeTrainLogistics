class Utils {
    static GenerateUniqueId = () => {
        const array = new Uint32Array(1);
        window.crypto.getRandomValues(array);
        return array[0].toString(16);
    }

    static CloneObject = (obj) => {
        if (typeof obj !== "object")
            throw new DOMException("Only objects can be cloned");

        return $.extend(true, {}, obj);
    }
}