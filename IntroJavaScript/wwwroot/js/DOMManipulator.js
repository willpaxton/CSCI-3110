'use strict';

export class DOMManipulator  {
    #skillCount = 0;

    static demonstrateDOMSelectors(){
            console.log("DOM SELECTOR EXAMPLES");

            const form = document.querySelector("#jobApplicationForm");
            console.log(form);

            const form2 = document.getElementById("#")
            console.log(form2);

            const allInputs = document.querySelectorAll('input');
            console.log(allInputs);

            const formSections = document.querySelectorAll(".form-section h2")
            console.log (formSections);
    }

    setUpEventListeners(){
        document.addEventListener('click', (e) => {
            if(e.target.getAttribute('id') === "addSkillBtn") {
                console.log("clicked");
            }
        })
    }

    addSkillField() {
        this.#skillCount += 1

        const skillContainer = document.getElementById('SkillsContainer')

        const skillDiv = document.createElement("div")
        skillDiv.className = 'skill-item';
        skillDiv.setAttribute('data-skill-id', this.#skillCount);   

        const label = document.createElement('label')
        label.setAttribute('for', 'skill$(this.#skillCount')
        label.textContent = 'Skill ${this.$skillCount}';

        const input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('id', `skill${this.#skillCount}`)
        input.setAttribute('name', `skill${this.#skillCount}`)
        input.setAttribute('placeholder', `e.g. JavaScript, Project Management`)

        const removeBtn = document.createElement('button');
        removeBtn.className = 'remove-btn remove-skill';
        removeBtn.textContent = 'Remove';
        removeBtn.setAttribute('type','button');

        skillDiv.appendChild(label);
        skillDiv.appendChild(input);
        skillDiv.appendChild(removeBtn);

        skillContainer.appendChild(skillDiv);
    }
}