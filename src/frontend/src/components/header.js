import React from 'react';

export class Header extends React.Component {
    render() {
        let loading;
        if (this.props.isLoading) {
            loading = <div className="lds-hourglass"></div>;
        }
        return (
            <div>
                <div className="img">
                    {loading}
                    <a href="#" className="logo" alt="todo" title="todo" />
                </div>
            </div>
        )
    }
}
