export class ElfWorkshop {
    // Do you think developer can add tasks directly to taskList
    // without passing by addTask method ?
    taskList: string[] = [];

    addTask(task: string): void {
        // The relative tests around empty tasks suggest can give you
        // some hints about way to improve the check.
        if (task !== "") {
            this.taskList.push(task);
        }
    }

    // If you read the method name, what do you expect as behavior ?
    // Completing the first task, the last one, a random one ?
    // Also, if there is no task, what do you expect ?
    // A string, or a string or null/undefined ?
    completeTask(): string {
        if (this.taskList.length > 0) {
            // With your suite test, it is simple to check behavior of shift here.
            // Have you tried to remove the if condition and see what happens ?
            return this.taskList.shift();
        }
        return null;
    }
}