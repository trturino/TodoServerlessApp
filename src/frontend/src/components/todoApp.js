import React from 'react';
import { Header } from './header';
import { TodoForm } from './todoForm';
import { TodoList } from './todoList';
import { Todo } from '../agent';
import { VisibilityFilters } from '../constants/actionTypes';
import { VisibilityFilter } from './visibilityFilter';
import * as uuidv1 from 'uuid/v1';

export class TodoApp extends React.Component {

    constructor() {
        super();
        this.state = {
            tasks: [],
            activeFilter: VisibilityFilters.SHOW_ALL,
            isLoading: false
        };
        this.addTask = this.addTask.bind(this);
        this.removeTask = this.removeTask.bind(this);
        this.doneTask = this.doneTask.bind(this);
        this.changeList = this.changeList.bind(this);
    }

    async componentDidMount() {
        this.isLoading(true);
        const allTasks = await Todo.all();
        this.isLoading(false);
        this.setState({ tasks: allTasks });
    }

    isLoading(value) {
        this.setState({ isLoading: value });
    }

    async addTask(task) {
        let updatedList = this.state.tasks;
        this.isLoading(true);
        const todo = { description: task, id: uuidv1() };
        await Todo.save(todo);
        this.isLoading(false);
        updatedList.push(todo);
        this.setState({ tasks: updatedList });
    }

    async removeTask(task_id) {
        let updatedList = this.state.tasks;
        const task = updatedList[task_id];
        this.isLoading(true);
        await Todo.remove(task.id);
        this.isLoading(false);
        updatedList.splice(task_id, 1);
        this.setState({ tasks: updatedList });
    }

    async doneTask(task_id) {
        let updatedList = this.state.tasks;
        const task = updatedList[task_id];
        this.isLoading(true);
        await Todo.done(task.id);
        this.isLoading(false);
        task.completed = true;
        this.setState({ tasks: updatedList });
    }

    async changeList(status) {
        let tasks = [];
        this.isLoading(true);
        
        switch (status) {
            case VisibilityFilters.SHOW_COMPLETED:
                tasks = await Todo.completed();
                break;
            case VisibilityFilters.SHOW_ACTIVE:
                tasks = await Todo.pending();
                break;
            default:
                tasks = await Todo.all();
                break;
        }

        this.isLoading(false);
        this.setState({
            tasks,
            activeFilter: status
        });
    }

    render() {
        const layout = (
            <div>
                <Header isLoading={this.state.isLoading} />
                <TodoForm addTask={this.addTask} />
                <TodoList myList={this.state.tasks}
                    addTask={this.addTask}
                    removeTask={this.removeTask}
                    doneTask={this.doneTask} />
                <VisibilityFilter changeList={this.changeList}
                    activeFilter={this.state.activeFilter} />
            </div>
        );
        return (
            <div>
                <div className="content">
                    {layout}
                </div>
            </div>
        )
    }
}