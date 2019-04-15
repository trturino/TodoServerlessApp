import React from 'react';
import { VisibilityFilters } from '../constants/actionTypes';

export class VisibilityFilter extends React.Component {

    constructor() {
        super();
        this.changeList = this.changeList.bind(this);
    }

    changeList(e) {
        this.props.changeList(e);
    }

    render() {
        return (
            <div className="todo-filter type1">
                <div className="right" id="listChanger">
                    <ul>
                        <li className={this.props.activeFilter === VisibilityFilters.SHOW_ALL ? 'active' : ''}>
                            <span onClick={e => this.changeList(VisibilityFilters.SHOW_ALL)}>All</span>
                        </li>
                        <li className={this.props.activeFilter === VisibilityFilters.SHOW_ACTIVE ? 'active' : ''}>
                            <span onClick={e => this.changeList(VisibilityFilters.SHOW_ACTIVE)}>Active</span>
                        </li>
                        <li className={this.props.activeFilter === VisibilityFilters.SHOW_COMPLETED ? 'active' : ''}>
                            <span onClick={e => this.changeList(VisibilityFilters.SHOW_COMPLETED)}>Completed</span>
                        </li>
                    </ul>
                </div>
            </div>
        );
    }
}