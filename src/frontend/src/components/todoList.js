import React from 'react';

export class TodoList extends React.Component {
    constructor() {
        super();
        this.remove = this.remove.bind(this);
        this.done = this.done.bind(this);
    }

    remove(e) {
        this.props.removeTask(e.target.parentNode.id);
    }

    done(e) {
        this.props.doneTask(e.target.parentNode.id);
    }
    
    render() {
        let items_left = 0;
        const items = this.props.myList.map((elem, i) => {
            return (
                <li key={i} id={i} className={elem.completed ? 'active' : 'passive'}>
                    <span className="id">{i + 1}</span>
                    <span className="title">{elem.description}</span>
                    <span className="type" onClick={this.done} />
                    <span className="delete" onClick={this.remove}></span>
                </li>
            )
        });
        return (
            <div className="todo-list type1">
                <ul>
                    {items}
                </ul>
            </div>
        );
    }
}