window.baffleInterop = {
    infiniteScramble: function (elementId) {
        console.log("from js file .................///////////////....");
        const el = document.getElementById(elementId);
        if (!el) return;

        if (!el.dataset.originalText) {
            el.dataset.originalText = el.textContent;
        }

        const b = baffle(el, {
            characters: '█▓▒░<>#日月山水火金土',
            speed: 20
        });

        el.style.transition = "opacity 1s ease-in-out";

        const scrambleCycle = () => {
            b.start();
            el.style.opacity = "0.7";

            setTimeout(() => {
                b.reveal(1400);
                el.style.opacity = "1";

                setTimeout(() => {
                    el.textContent = el.dataset.originalText;
                    setTimeout(() => {
                        scrambleCycle(); // Repeat the cycle infinitely
                    }, 1500);
                }, 1500);
            }, 300);
        };

        scrambleCycle();
    },
    X: function (email) {
        console.log("Received email from Blazor:", email);
    },

    scrambleThenReset: function (elementId) {
        const el = document.getElementById(elementId);
        

        if (!el.dataset.originalText) {
            el.dataset.originalText = el.textContent;
        }

        if (el.dataset.animating === "true") return;
        el.dataset.animating = "true";

        const b = baffle(el, {
            characters: '日月山水火木金土█▓▒░<>#/',
            speed: 25
        });

        b.start();

        setTimeout(() => {
            b.reveal(1200);
            el.style.transition = "opacity 0.4s ease-in-out";
            el.style.opacity = "0.6";

            setTimeout(() => {
                el.textContent = el.dataset.originalText;
                el.style.opacity = "1";
                el.dataset.animating = "false";
            }, 1400);
        }, 150);
    }
};
