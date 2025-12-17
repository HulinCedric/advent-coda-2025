import {ElfWorkshop} from "../src/elfWorkshop";

// We can read tests as an executable specification of the expected behavior.
// Like a story, it is good for our brain to have a consistency in the way
// we name them to easily understand what is being tested, and what is expected.
// For example, we can use the format 'methodName should do something'.
// or 'methodName when condition should do something'.
// or again 'should do something when condition'.
// You can be creative, and put yourself in the shoes of the reader.
// After that, consistency is the key.
describe('ElfWorkshop Tasks', () => {

    // Did you notice that removeTask is not the method being tested here?
    test('removeTask should add a task', () => {
        const workshop = new ElfWorkshop();
        workshop.addTask("Build toy train");
        expect(workshop.taskList).toContain("Build toy train");
    });

    // I guess that both 'test2' is to be sure that addTask works as expected.
    // Do you know about parameterized tests? They allow you to run the
    // same test with different inputs.
    test('test2 checks for task addition', () => {
        const workshop = new ElfWorkshop();
        workshop.addTask("Craft dollhouse");

        // Do you prefer the toContain or the includes + toBeTruthy ?
        // What is clearer when the test fails?
        // Choose one and stick to it for consistency.
        expect(workshop.taskList.includes("Craft dollhouse")).toBeTruthy();
    });

    test('test2 checks for task addition', () => {
        const workshop = new ElfWorkshop();
        workshop.addTask("Paint bicycle");
        expect(workshop.taskList.includes("Paint bicycle")).toBeTruthy();
    });

    // Have you thought about empty inputs like "", "   ", "\n", null, undefined
    // Remember about parameterized tests for these cases.
    // This will help you avoid to repeat the test many times the same behavior.
    test('Should handle empty tasks correctly', () => {
        const workshop = new ElfWorkshop();
        workshop.addTask("");
        expect(workshop.taskList.length).toBe(0);
    });

    // This test is good.
    // Can we gain in clarity by mentioning completion of the task
    // and not removed one ?
    // Also, did you think this should be nice to expose that completion
    // of task if the first in the list ?
    // By adding two tasks and completing one, we can be sure of
    // that by asserting on the remaining tasks.
    test('Task removal functionality', () => {
        const workshop = new ElfWorkshop();
        workshop.addTask("Wrap gifts");
        const removedTask = workshop.completeTask();
        expect(removedTask).toBe("Wrap gifts");
        expect(workshop.taskList.length).toBe(0);
    });

    // What is the behavior when we try to complete a task when there is none ?
});