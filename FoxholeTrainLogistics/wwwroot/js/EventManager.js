class EventManager {

    static AddEventListener (eventName, fn)  {
        document.addEventListener(eventName, ({ detail }) => fn(detail));
    }

    static DispatchEvent (eventName, data = undefined) {
        const event = new CustomEvent(eventName, { detail: data });
        document.dispatchEvent(event);
    }
}